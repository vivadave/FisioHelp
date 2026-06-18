using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using FisioHelp.DataModels;
using NpgsqlTypes;

namespace FisioHelp.Helper
{
    public static class StsService
    {
        static StsService()
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
        }

        private static readonly HttpClient _httpClient = CreateHttpClient();

        private static HttpClient CreateHttpClient()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (request, cert, chain, errors) =>
            {
                // Sogei's sandbox TLS certificate is issued by "Sogei Certification Authority Test",
                // a CA not publicly distributed (no AIA, CRL only reachable from Sogei's internal network).
                // Trust is bypassed only in the sandbox; production keeps standard validation.
                if (IsTestEnvironment)
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return new HttpClient(handler);
        }

        private static bool IsTestEnvironment =>
            string.Equals(
                ConfigurationManager.AppSettings["STS_UseTestEnvironment"], "true",
                StringComparison.OrdinalIgnoreCase);

        private static string Endpoint =>
            IsTestEnvironment
                ? ConfigurationManager.AppSettings["STS_Endpoint_Test"]
                : ConfigurationManager.AppSettings["STS_Endpoint_Prod"];

        private static string QueryEndpoint =>
            IsTestEnvironment
                ? ConfigurationManager.AppSettings["STS_QueryEndpoint_Test"]
                : ConfigurationManager.AppSettings["STS_QueryEndpoint_Prod"];

        // Sandbox identifies the sender using Sogei's fixed test CF/P.IVA pair, unrelated to the
        // therapist's real CF/P.IVA (which stay on invoices). Production always uses the real ones.
        private static string OwnerFiscalCode(Therapist therapist) =>
            IsTestEnvironment ? ConfigurationManager.AppSettings["STS_TestFiscalCode"] : therapist.FiscalCode;

        private static string OwnerTaxNumber(Therapist therapist) =>
            IsTestEnvironment ? ConfigurationManager.AppSettings["STS_TestTaxNumber"] : therapist.TaxNumber;

        // The "AltriProfessionisti" sandbox test user is only authorized for tipoSpesa "SP";
        // production uses "SR" (Spese Riabilitative), matching the physiotherapy category.
        private static string TipoSpesa =>
            IsTestEnvironment ? ConfigurationManager.AppSettings["STS_TestTipoSpesa"] : "SR";

        private static string EncryptField(string plainText)
        {
            var certPath = System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "Resources", "SanitelCF.cer");
            var cert = new X509Certificate2(certPath);
            using (var rsa = (RSACryptoServiceProvider)cert.PublicKey.Key)
            {
                byte[] encrypted = rsa.Encrypt(Encoding.UTF8.GetBytes(plainText), false);
                return Convert.ToBase64String(encrypted);
            }
        }

        private static string BuildSoapEnvelope(Invoice invoice, Customer customer, Therapist therapist)
        {
            string encryptedPincode = EncryptField(therapist.StsPincode);
            string encryptedCfProprietario = EncryptField(OwnerFiscalCode(therapist));
            string encryptedCfCittadino = EncryptField(customer.Fiscalcode);

            string invoiceDate = ((DateTime)invoice.Date).ToString("yyyy-MM-dd");
            string pagamentoTracciato = invoice.Contanti ? "NO" : "SI";
            string importo = invoice.Total.ToString("F2", System.Globalization.CultureInfo.InvariantCulture);

            return $@"<?xml version=""1.0"" encoding=""UTF-8""?>
<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/""
                  xmlns:doc=""http://documentospesap730.sanita.finanze.it"">
  <soapenv:Header/>
  <soapenv:Body>
    <doc:inserimentoDocumentoSpesaRequest>
      <doc:pincode>{encryptedPincode}</doc:pincode>
      <doc:Proprietario>
        <doc:cfProprietario>{encryptedCfProprietario}</doc:cfProprietario>
      </doc:Proprietario>
      <doc:idInserimentoDocumentoFiscale>
        <doc:idSpesa>
          <doc:pIva>{OwnerTaxNumber(therapist)}</doc:pIva>
          <doc:dataEmissione>{invoiceDate}</doc:dataEmissione>
          <doc:numDocumentoFiscale>
            <doc:dispositivo>1</doc:dispositivo>
            <doc:numDocumento>{invoice.Title}</doc:numDocumento>
          </doc:numDocumentoFiscale>
        </doc:idSpesa>
        <doc:dataPagamento>{invoiceDate}</doc:dataPagamento>
        <doc:cfCittadino>{encryptedCfCittadino}</doc:cfCittadino>
        <doc:voceSpesa>
          <doc:tipoSpesa>{TipoSpesa}</doc:tipoSpesa>
          <doc:importo>{importo}</doc:importo>
          <doc:naturaIVA>N2.2</doc:naturaIVA>
        </doc:voceSpesa>
        <doc:pagamentoTracciato>{pagamentoTracciato}</doc:pagamentoTracciato>
        <doc:tipoDocumento>F</doc:tipoDocumento>
        <doc:flagOpposizione>0</doc:flagOpposizione>
      </doc:idInserimentoDocumentoFiscale>
    </doc:inserimentoDocumentoSpesaRequest>
  </soapenv:Body>
</soapenv:Envelope>";
        }

        private static (bool success, string message) ParseSoapResponse(string responseXml)
        {
            try
            {
                XNamespace ns = "http://documentospesap730.sanita.finanze.it";
                var doc = XDocument.Parse(responseXml);
                var body = doc.Root
                    ?.Element(XName.Get("Body", "http://schemas.xmlsoap.org/soap/envelope/"));
                var responseEl = body?.Element(ns + "inserimentoDocumentoSpesaResponse");

                string esito = responseEl?.Element(ns + "esitoChiamata")?.Value ?? "ERR";

                var messages = new System.Collections.Generic.List<string>();
                bool hasBlockingError = false;
                var messaggi = responseEl?.Element(ns + "listaMessaggi");
                if (messaggi != null)
                {
                    foreach (var msg in messaggi.Elements(ns + "messaggio"))
                    {
                        string codice = msg.Element(ns + "codice")?.Value ?? "";
                        string descrizione = msg.Element(ns + "descrizione")?.Value;
                        messages.Add($"[{codice}] {descrizione}");

                        // Codes are prefixed by severity: "S..." = blocking error (Segnalazione),
                        // "W..." = non-blocking warning, "0" = success confirmation.
                        if (codice.StartsWith("S", StringComparison.OrdinalIgnoreCase))
                            hasBlockingError = true;
                    }
                }

                if (hasBlockingError)
                    return (false, messages.Count > 0 ? string.Join(Environment.NewLine, messages) : $"Errore STS (esito: {esito})");

                return (true, messages.Count > 0 ? string.Join(Environment.NewLine, messages) : null);
            }
            catch (Exception ex)
            {
                return (false, $"Cannot parse STS response: {ex.Message}");
            }
        }

        public static async Task<(bool success, string error)> SendInvoiceAsync(
            Invoice invoice, Customer customer, Therapist therapist)
        {
            if (customer.StsOpponent)
                return (false, "Il paziente si è opposto all'invio dei dati al Sistema Tessera Sanitaria.");

            if (string.IsNullOrWhiteSpace(therapist.StsPincode))
                return (false, "Pincode STS non configurato. Impostarlo nelle Impostazioni.");

            if (string.IsNullOrWhiteSpace(therapist.StsPassword))
                return (false, "Password STS non configurata. Impostarla nelle Impostazioni.");

            if (string.IsNullOrWhiteSpace(therapist.FiscalCode))
                return (false, "Codice Fiscale del terapeuta non configurato.");

            if (string.IsNullOrWhiteSpace(therapist.TaxNumber))
                return (false, "Partita IVA del terapeuta non configurata.");

            if (string.IsNullOrWhiteSpace(customer.Fiscalcode))
                return (false, "Codice Fiscale del paziente mancante.");

            try
            {
                string soapXml = BuildSoapEnvelope(invoice, customer, therapist);
                string endpoint = Endpoint;

                var credentials = Convert.ToBase64String(
                    Encoding.ASCII.GetBytes($"{OwnerFiscalCode(therapist)}:{therapist.StsPassword}"));

                var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", credentials);
                request.Headers.Add("SOAPAction", "inserimento.documentospesap730.sanita.finanze.it");
                request.Content = new StringContent(soapXml, Encoding.UTF8, "text/xml");

                var response = await _httpClient.SendAsync(request);
                string responseBody = await response.Content.ReadAsStringAsync();

                var (success, message) = ParseSoapResponse(responseBody);
                if (success)
                {
                    invoice.StsSent = true;
                    invoice.StsSentDate = new NpgsqlDate(DateTime.Today);
                    invoice.SaveToDB();
                    return (true, message);
                }

                return (false, message);
            }
            catch (Exception ex)
            {
                return (false, $"Errore di connessione: {ex.Message}");
            }
        }

        private static string BuildQuerySoapEnvelope(Invoice invoice, Therapist therapist)
        {
            string encryptedPincode = EncryptField(therapist.StsPincode);
            string encryptedCfProprietario = EncryptField(OwnerFiscalCode(therapist));
            string invoiceDate = ((DateTime)invoice.Date).ToString("yyyy-MM-dd");

            return $@"<?xml version=""1.0"" encoding=""UTF-8""?>
<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/""
                  xmlns:int=""http://interrogazionepuntuale.p730.sanita.finanze.it"">
  <soapenv:Header/>
  <soapenv:Body>
    <int:interrogazionePuntualeRequest>
      <int:pincode>{encryptedPincode}</int:pincode>
      <int:Proprietario>
        <int:cfProprietario>{encryptedCfProprietario}</int:cfProprietario>
      </int:Proprietario>
      <int:idDocumentoFiscale>
        <int:pIva>{OwnerTaxNumber(therapist)}</int:pIva>
        <int:dataEmissione>{invoiceDate}</int:dataEmissione>
        <int:numDocumentoFiscale>
          <int:dispositivo>1</int:dispositivo>
          <int:numDocumento>{invoice.Title}</int:numDocumento>
        </int:numDocumentoFiscale>
      </int:idDocumentoFiscale>
    </int:interrogazionePuntualeRequest>
  </soapenv:Body>
</soapenv:Envelope>";
        }

        private static (bool found, string details) ParseQueryResponse(string responseXml)
        {
            try
            {
                XNamespace ns = "http://interrogazionepuntuale.p730.sanita.finanze.it";
                var doc = XDocument.Parse(responseXml);
                var body = doc.Root
                    ?.Element(XName.Get("Body", "http://schemas.xmlsoap.org/soap/envelope/"));
                var responseEl = body?.Element(ns + "interrogazionePuntualeResponse");

                var documento = responseEl?.Element(ns + "documentoFiscale");

                var messages = new System.Collections.Generic.List<string>();
                var messaggi = responseEl?.Element(ns + "listaMessaggi");
                if (messaggi != null)
                {
                    foreach (var msg in messaggi.Elements(ns + "messaggio"))
                    {
                        string codice = msg.Element(ns + "codice")?.Value ?? "";
                        string descrizione = msg.Element(ns + "descrizione")?.Value;
                        messages.Add($"[{codice}] {descrizione}");
                    }
                }

                if (documento == null)
                    return (false, messages.Count > 0 ? string.Join(Environment.NewLine, messages) : "Documento non trovato su STS.");

                string protocollo = documento.Element(ns + "protocollo")?.Value;
                string dataInvio = documento.Element(ns + "dataInvio")?.Value;
                var details = $"Protocollo: {protocollo ?? "n/d"}{Environment.NewLine}Data invio: {dataInvio ?? "n/d"}";
                if (messages.Count > 0)
                    details += Environment.NewLine + string.Join(Environment.NewLine, messages);

                return (true, details);
            }
            catch (Exception ex)
            {
                return (false, $"Cannot parse STS response: {ex.Message}");
            }
        }

        public static async Task<(bool found, string details)> CheckInvoiceStatusAsync(
            Invoice invoice, Therapist therapist)
        {
            if (string.IsNullOrWhiteSpace(therapist.StsPincode))
                return (false, "Pincode STS non configurato. Impostarlo nelle Impostazioni.");

            if (string.IsNullOrWhiteSpace(therapist.StsPassword))
                return (false, "Password STS non configurata. Impostarla nelle Impostazioni.");

            try
            {
                string soapXml = BuildQuerySoapEnvelope(invoice, therapist);

                var credentials = Convert.ToBase64String(
                    Encoding.ASCII.GetBytes($"{OwnerFiscalCode(therapist)}:{therapist.StsPassword}"));

                var request = new HttpRequestMessage(HttpMethod.Post, QueryEndpoint);
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", credentials);
                request.Headers.Add("SOAPAction", "interrogazionepuntuale.p730.sanita.finanze.it");
                request.Content = new StringContent(soapXml, Encoding.UTF8, "text/xml");

                var response = await _httpClient.SendAsync(request);
                string responseBody = await response.Content.ReadAsStringAsync();

                return ParseQueryResponse(responseBody);
            }
            catch (Exception ex)
            {
                return (false, $"Errore di connessione: {ex.Message}");
            }
        }
    }
}
