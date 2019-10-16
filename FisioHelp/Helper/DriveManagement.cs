using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Newtonsoft.Json;

namespace FisioHelp.Helper
{
  public static  class DriveManagement
  {
    public static DriveService Connect()
    {
      try
      {
        // Get active credential
        string serviceAccountCredentialFilePath = @"Resources/fluted-polymer-256106-8fdab3f72fb5.json";

        string[] scopes = new string[] { DriveService.Scope.Drive, DriveService.Scope.DriveFile };
        GoogleCredential credential;
        using (var stream = new FileStream(serviceAccountCredentialFilePath, FileMode.Open, FileAccess.Read))
        {
          credential = GoogleCredential.FromStream(stream).CreateScoped(scopes);
        }

        // Create the  Analytics service.
        return new DriveService(new BaseClientService.Initializer()
        {
          HttpClientInitializer = credential,
          ApplicationName = "PhisioHelp",
        });
      }
      catch (Exception ex)
      {
        throw new Exception("CreateServiceAccountDriveFailed", ex);
      }
    }
  }
}
