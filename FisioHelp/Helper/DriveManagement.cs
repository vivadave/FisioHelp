using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Drive.v3.Data;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FisioHelp.Helper
{
  public static  class DriveManagement
  {
    private static DriveService Connect()
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
 
    public static void DeleteAll()
    {
      var service = Connect();
      var listRequest = service.Files.List();

      listRequest.Q = $"mimeType='application/vnd.google-apps.folder'";     
      listRequest.Spaces = "drive";
      var result = listRequest.Execute();

      foreach (var f in result.Files)
        service.Files.Delete(f.Id).Execute();
    }

    private static string InsertFolder(DriveService service, string folderName, List<string> parentIds)
    {
      var listRequest = service.Files.List();

      var folderIds = new List<string>();

      var parentsQuery = string.Join(" and ", parentIds.Select(x => $"'{x}' in parents "));

      listRequest.Q = $"mimeType='application/vnd.google-apps.folder' and name = '{folderName}'";
      if (!string.IsNullOrEmpty(parentsQuery))
        listRequest.Q += $" and {parentsQuery}";

      listRequest.Spaces = "drive";
      var result = listRequest.Execute();
      var folderFound = result.Files.FirstOrDefault(x => x.Name == folderName);
      if (folderFound != null)
        return folderFound.Id;

      return UploadFolder(service, folderName, parentIds);
    }

    public static string InsertFilePdf(string filepath, List<string> folderNames)
    {
      var service = Connect();
      FileInfo fileInfo = new FileInfo(filepath);
      var fileName = fileInfo.Name;

      var folderIds = new List<string>();
      foreach (var folder in folderNames)
      {
        var id = InsertFolder(service, folder, folderIds);
        folderIds.Add(id);
      }

      var parentsQuery = string.Join(" and ", folderIds.Select(x => $"'{x}' in parents "));
      
      var listRequest = service.Files.List();
      listRequest.Q = $"mimeType='application/pdf' and name = '{fileName}'";
      if (!string.IsNullOrEmpty(parentsQuery))
        listRequest.Q += $" and {parentsQuery}";

      listRequest.Spaces = "drive";
      var result = listRequest.Execute();
      var folderFound = result.Files.FirstOrDefault(x => x.Name == fileName);
      if (folderFound != null)
        return folderFound.Id;

      return UploadFile(service, filepath, folderIds);
    }

    private static string UploadFile(DriveService service, string filepath, List<string> folderIds)
    {
      FileInfo fileInfo = new FileInfo(filepath);
      var fileName = fileInfo.Name;
      var lastParent = folderIds[folderIds.Count - 1];

      var fileMetadata = new Google.Apis.Drive.v3.Data.File()
      {
        Name = fileName,
        MimeType = "application/pdf",
        Parents = new List<string> { lastParent }
      };


      FilesResource.CreateMediaUpload request;
      using (var stream = new System.IO.FileStream(filepath,
                              System.IO.FileMode.Open))
      {
        request = service.Files.Create(
            fileMetadata, stream, "application/pdf");
        request.Fields = "id";
        request.Upload();
      }
      var file = request.ResponseBody;

      Permission newPermission = new Permission();

      newPermission.EmailAddress = "piaia.osteopatia@gmail.com";
      newPermission.Type = "user";
      newPermission.Role = "writer";
      try
      {
         service.Permissions.Create(newPermission, file.Id).Execute();
      }
      catch (Exception e)
      {
        Console.WriteLine("An error occurred: " + e.Message);
      }

      return file.Id;
    }

    private static string UploadFolder(DriveService service, string folderName, List<string> parentIds)
    {
      var fileMetadata = new Google.Apis.Drive.v3.Data.File()
      {
        Name = folderName,
        MimeType = "application/vnd.google-apps.folder"
      };

      if (parentIds.Count > 0)
        fileMetadata.Parents = parentIds;

      var folder = service.Files.Create(fileMetadata).Execute();

      Permission newPermission = new Permission();

      newPermission.EmailAddress = "piaia.osteopatia@gmail.com";
      newPermission.Type = "user";
      newPermission.Role = "writer";
      try
      {
        service.Permissions.Create(newPermission, folder.Id).Execute();
      }
      catch (Exception e)
      {
        Console.WriteLine("An error occurred: " + e.Message);
      }

      return folder.Id;
    }
   
  }
}
