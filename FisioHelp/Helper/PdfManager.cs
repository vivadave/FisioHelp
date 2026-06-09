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
	    // Scarica Chromium
	    await new BrowserFetcher().DownloadAsync();

	    // Avvia browser
	    var browser = await Puppeteer.LaunchAsync(new LaunchOptions
	    {
		    Headless = true
	    });

	    try
	    {
		    var page = await browser.NewPageAsync();

		    // Carica HTML
		    await page.SetContentAsync(html);

		    // Genera PDF
		    await page.PdfAsync(outputPdf, new PdfOptions
		    {
			    Format = PaperFormat.A4,
			    PrintBackground = true
		    });
	    }
	    finally
	    {
		    await browser.CloseAsync();
	    }

    }


  }
}
