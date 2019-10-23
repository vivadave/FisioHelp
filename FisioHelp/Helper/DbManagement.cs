using System;
using LinqToDB;
using System.IO;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Diagnostics;

namespace FisioHelp.Helper
{
  public static class DbManagement
  {
    public static Guid SaveToDB<T>(T model)
    {
      var a = model as DataModels.BaseModel;
      using (var db = new Db.PhisioDB())
      {
        if (a.Id != null && a.Id != Guid.Empty)
          db.Update(model);
        else
        {
          a.Id = Guid.NewGuid();
          a.Id = Guid.Parse(db.InsertWithIdentity(model).ToString());
        }

        return a.Id;
      }
    }

    public static void PostgreSqlDump(string outFile)
    {
      var connection =  System.Configuration.ConfigurationManager.ConnectionStrings["Phisio"].ConnectionString;
      var sonnectionParts = connection.Split(';');
      var host = sonnectionParts.FirstOrDefault(x => x.StartsWith("Server="))?.Replace("Server=", "");
      var port = sonnectionParts.FirstOrDefault(x => x.StartsWith("Port="))?.Replace("Port=", "");
      var database = sonnectionParts.FirstOrDefault(x => x.StartsWith("Database="))?.Replace("Database=", "");
      var user = sonnectionParts.FirstOrDefault(x => x.StartsWith("User Id="))?.Replace("User Id=", "");
      var password = sonnectionParts.FirstOrDefault(x => x.StartsWith("Password="))?.Replace("Password=", "");

      var pgDumpPath =Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\PGDUMP\pg_dump.exe");

      String dumpCommand = "\"" + pgDumpPath + "\"" + " -Fc" + " -h " + host + " -p " + port + " -d " + database + " -U " + user + " -F p";
      String passFileContent = "" + host + ":" + port + ":" + database + ":" + user + ":" + password + "";

      String batFilePath = Path.Combine( Path.GetTempPath(), Guid.NewGuid().ToString() + ".bat");

      String passFilePath = Path.Combine( Path.GetTempPath(), Guid.NewGuid().ToString() + ".conf");

      try
      {
        String batchContent = "";
        batchContent += "@" + "set PGPASSFILE=" + passFilePath + "\n";
        batchContent += "@" + dumpCommand + "  > " + "\"" + outFile + "\"" + "\n";

        File.WriteAllText( batFilePath, batchContent, Encoding.ASCII);

        File.WriteAllText( passFilePath, passFileContent, Encoding.ASCII);

        if (File.Exists(outFile))
          File.Delete(outFile);

        ProcessStartInfo oInfo = new ProcessStartInfo(batFilePath);
        oInfo.UseShellExecute = false;
        oInfo.CreateNoWindow = true;

        using (Process proc = System.Diagnostics.Process.Start(oInfo))
        {
          proc.WaitForExit();
          proc.Close();
        }
      }
      finally
      {
        if (File.Exists(batFilePath))
          File.Delete(batFilePath);

        if (File.Exists(passFilePath))
          File.Delete(passFilePath);
      }
    }
  }
}
