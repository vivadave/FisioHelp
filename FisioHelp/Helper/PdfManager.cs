using System;
using PuppeteerSharp;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using PuppeteerSharp.Media;

namespace FisioHelp.Helper
{

  public static class PdfManager
  {
	private static readonly string LogFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pdf_debug.log");

	private static string FindLocalChrome()
	{
	  var candidates = new[]
	  {
        "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe",
        Path.Combine(Environment.GetEnvironmentVariable("ProgramW6432") ?? "", @"Google\Chrome\Application\chrome.exe"),
		Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), @"Google\Chrome\Application\chrome.exe"),
		Path.Combine(Environment.GetEnvironmentVariable("ProgramFiles(x86)") ?? "", @"Google\Chrome\Application\chrome.exe"),
		Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Google\Chrome\Application\chrome.exe"),
	  };
	  foreach (var path in candidates)
		if (File.Exists(path)) return path;
	  return null;
	}

	private static void Log(string message)
	{
	  var line = $"[{DateTime.Now:HH:mm:ss.fff}] {message}";
	  System.Diagnostics.Debug.WriteLine(line);
	  try { File.AppendAllText(LogFile, line + Environment.NewLine); } catch { }
	}

	public static void CreatePdf(string pdfPath, string htmlPath)
	{
	  var process = new System.Diagnostics.Process();
	  process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
	  var chrome = Path.Combine(Environment.GetEnvironmentVariable("ProgramFiles(x86)"), @"Google\Chrome\Application\chrome.exe");

	  // use powershell
	  process.StartInfo.FileName = "powershell";
	  // set the Chrome path as local variable in powershell and run
	  process.StartInfo.Arguments = $@"$chrome='{ chrome }'; & $chrome --headless=old --print-to-pdf='{pdfPath}' '{htmlPath}'";
	  process.Start();
	  Thread.Sleep(4000);
	}

	public static async Task CreatePdfNew(string outputPdf, string html)
	{
	  var chromePath = FindLocalChrome();
	  if (chromePath == null)
	  {
		var msg = "Chrome non trovato. Installare Google Chrome.";
		Log(msg);
		throw new InvalidOperationException(msg);
	  }

	  // Avvia browser usando Chrome già installato
	  var browser = await Puppeteer.LaunchAsync(new LaunchOptions
	  {
		Headless = true,
		ExecutablePath = chromePath
	  }).ConfigureAwait(false);

	  try
	  {
		var page = await browser.NewPageAsync().ConfigureAwait(false);

		await page.SetContentAsync(html).ConfigureAwait(false);

		await page.PdfAsync(outputPdf, new PdfOptions
		{
		  Format = PaperFormat.A4,
		  PrintBackground = true
		}).ConfigureAwait(false);
	  }
	  catch (Exception ex)
	  {
		Log($"ERRORE: {ex.GetType().Name} — {ex.Message}{Environment.NewLine}{ex.StackTrace}");
		throw;
	  }
	  finally
	  {
		await browser.CloseAsync().ConfigureAwait(false);
	  }
	}


  }
}
