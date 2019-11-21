using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

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
      process.StartInfo.Arguments = $@"$chrome='{ chrome }'; & $chrome --headless --print-to-pdf='{pdfPath}' '{htmlPath}'";
      process.Start();
      Thread.Sleep(1500);
    }

  }
}
