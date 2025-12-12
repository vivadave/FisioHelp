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
  using DataModels.Enums;

  public static  class DriveManagement
  {
    private static string[] _applicationType = { "application/pdf", "application/sql" };

    private static DriveService Connect()
    {
      try
      {
         // Get active credential
        string serviceAccountCredentialFilePath = @"Resources/fluted-polymer-256106-807538c38adc.json";

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
      {
        DeleteInFolderWithId(f.Id, DataModels.Enums.FileType.pdf, 0);
      }
    }

    public static void DeleteInFolderWithId(string folderId, FileType fileType, int olderThenDays)
    {

      if (!Helper.CheckForInternetConnection())
      {
        //"ERROR: no internet connection"
        return;
      }

      var service = Connect();
      var listRequest = service.Files.List();
      var mimeType = _applicationType[(int)fileType];

      var date = DateTime.Today.AddDays((-1) * olderThenDays);

      listRequest.Q = $"mimeType='{mimeType}' and '{folderId}' in parents and createdTime < '{date.ToString("yyyy-MM-dd")}'";
      listRequest.Spaces = "drive";
      var result = listRequest.Execute();

      foreach (var f in result.Files)
        service.Files.Delete(f.Id).Execute();
    }

    public static void DeleteInFolder(string folder, FileType fileType , int olderThenDays)
    {

        if (!Helper.CheckForInternetConnection())
        {
            //"ERROR: no internet connection"
            return;
        }

      var service = Connect();
      var listRequest = service.Files.List();
      var mimeType = _applicationType[(int)fileType];
      var folderId = InsertFolder(service, folder, new List<string>());

      var date = DateTime.Today.AddDays((-1) * olderThenDays);

      listRequest.Q = $"mimeType='{mimeType}' and '{folderId}' in parents and createdTime < '{date.ToString("yyyy-MM-dd")}'";
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

    public static string InsertFile(string filepath, List<string> folderNames, FileType fileType)
    {
#if DEBUG
      return "debug";
#endif
      if (!Helper.CheckForInternetConnection())
      {
        return "ERROR: no internet connection";
      }

      var mimeType = _applicationType[(int)fileType];

      var service = Connect();
      FileInfo fileInfo = new FileInfo(filepath);
      var fileName = fileInfo.Name;

      var folderIds = new List<string>();
      foreach (var folder in folderNames)
      {
        var id = InsertFolder(service, folder, folderIds);
        folderIds.Add(id);
      }

      var lastParent = folderIds[folderIds.Count - 1];
      var parentsQuery = $"'{lastParent}' in parents ";
      
      var listRequest = service.Files.List();
      listRequest.Q = $"mimeType='{mimeType}' and name = '{fileName}'";
      if (!string.IsNullOrEmpty(parentsQuery))
        listRequest.Q += $" and {parentsQuery}";

      listRequest.Spaces = "drive";
      var result = listRequest.Execute();
      var folderFound = result.Files.FirstOrDefault(x => x.Name == fileName);
      if (folderFound != null)
        return folderFound.Id;

      return UploadFile(service, filepath, folderIds, fileType);
    }

    private static string UploadFile(DriveService service, string filepath, List<string> folderIds, FileType fileType)
    {
      FileInfo fileInfo = new FileInfo(filepath);
      var fileName = fileInfo.Name;
      var lastParent = folderIds[folderIds.Count - 1];
      var mimeType = _applicationType[(int)fileType];

      var fileMetadata = new Google.Apis.Drive.v3.Data.File()
      {
        Name = fileName,
        MimeType = mimeType,
        Parents = new List<string> { lastParent }
      };


      FilesResource.CreateMediaUpload request;
      using (var stream = new System.IO.FileStream(filepath,
                              System.IO.FileMode.Open))
      {
        request = service.Files.Create(
            fileMetadata, stream, mimeType);
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
        var permission = service.Permissions.Create(newPermission, file.Id);
        permission.SendNotificationEmail = false;
        permission.Execute();
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
