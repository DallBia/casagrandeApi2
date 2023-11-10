using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Threading.Tasks; 
using File = Google.Apis.Drive.v3.Data.File;

public class GoogleDriveService
{
    private DriveService _service;

    public GoogleDriveService(string credentialsFilePath, string applicationName)
    {
        UserCredential credential;
        using (var stream = new FileStream(credentialsFilePath, FileMode.Open, FileAccess.Read))
        {
            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.Load(stream).Secrets,
                new[] { DriveService.Scope.Drive },
                "user", CancellationToken.None, new FileDataStore("Drive.Auth.Store"))
                .Result;
        }

        _service = new DriveService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = applicationName
        });
    }

    public async Task<string> UploadImageToGoogleDrive(string base64String, int userId)
    {
        try
        {
            // Converter Base64 para bytes
            byte[] bytes = Convert.FromBase64String(base64String);

            // Salvar o arquivo localmente
            string fileName = $"E{userId:D6}.jpg";
            string localFilePath = Path.Combine(Path.GetTempPath(), fileName);
            using (var fileStream = new FileStream(localFilePath, FileMode.Create))
            {
                await fileStream.WriteAsync(bytes, 0, bytes.Length);
            }
            

            // Enviar o arquivo para o Google Drive
            var fileMetadata = new File()
            {
                Name = fileName
            };

            using (var mediaStream = new FileStream(localFilePath, FileMode.Open))
            {
                var request = _service.Files.Create(fileMetadata, mediaStream, "image/jpeg");
                await request.UploadAsync();
                var file = request.ResponseBody;

                // Obter o link compartilhado do arquivo
                var fileId = file.Id;
                var getRequest = _service.Files.Get(fileId);
                getRequest.Fields = "webViewLink";
                var responseFile = await getRequest.ExecuteAsync();
                var webViewLink = responseFile.WebViewLink;

                // Deletar o arquivo local após o upload
                var fileInfo = new FileInfo(localFilePath);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }

                return webViewLink;
            }
        }
        catch (Exception ex)
        {
            // Lidar com exceções, registrar ou lançar conforme necessário
            throw ex;
        }
    }
}

