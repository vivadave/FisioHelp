using System;
using System.Collections.Generic;
using System.IO;
using System.Timers;

namespace FisioHelp.Helper
{
  using DataModels.Enums;

  public static class BackupManager
  {
    private static Timer invoiceBackupTimer;
    private static readonly int checkDateDays = 15;
    private static int _begin = 0;

    public static void SetBackupTimer(DataModels.Therapist terapist)
    {
      invoiceBackupTimer = new Timer(1000 * 60 * 60);
      invoiceBackupTimer.Elapsed += (sender, e) => { OnBackupTimerEvent(terapist); };
      invoiceBackupTimer.AutoReset = true;
      invoiceBackupTimer.Enabled = true;
    }

    private static void OnBackupTimerEvent(DataModels.Therapist terapist)
    {
      if (_begin > 0)
      {
        _begin--;
        return;
      }
      _begin = 100;

      BackupPdf(terapist.InvoicesFolder, "Invoice");
      BackupPdf(terapist.PrivacyFolder, "Privacy");

      _begin = 0;
    }


    private static void BackupPdf(string folder, string type)
    {
      foreach (string monthsDir in Directory.GetDirectories(folder))
      {
        DateTime dtMonthsDir = Directory.GetCreationTime(monthsDir);

        //avoid checking  obsolete directory
        if (DateTime.Now.Subtract(dtMonthsDir).TotalDays > (81 + checkDateDays))
          continue;

        var files = Directory.GetFiles(monthsDir);
        foreach (var file in files)
        {
          var fileInfo = new FileInfo(file);
          if (DateTime.Now.Subtract(fileInfo.CreationTime).TotalDays > checkDateDays)
            continue;

          if (fileInfo.Extension != ".pdf")
            continue;

          var date = new DirectoryInfo(monthsDir).Name;
          DriveManagement.InsertFile(file, new List<string> { type, date }, FileType.pdf);
        }
      }
    }
  }
}
