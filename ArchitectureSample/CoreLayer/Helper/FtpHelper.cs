using CoreLayer.Entity.ViewModel.FtpHelper;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace CoreLayer.Helper
{
    public static class FtpHelper
    {
        public static bool UploadFileToFtp(string ftpServer, string ftpUsername, string ftpPassword, string localFilePath, string remoteFilePath)
        {
            //// FTP bağlantı bilgileri
            //string ftpServer = "ftp://example.com";
            //string ftpUsername = "yourUsername";
            //string ftpPassword = "yourPassword";

            //// Yükleyeceğiniz dosyanın yolu
            //string localFilePath = @"C:\Path\To\Your\File.txt";

            //// FTP'de kaydedilecek dosyanın yolu ve adı
            //string remoteFilePath = "/public_html/yourfile.txt";

            //// FTP'ye dosya yükleme işlemi
            //UploadFileToFtp(ftpServer, ftpUsername, ftpPassword, localFilePath, remoteFilePath);
            try
            {
                // FTP'ye bağlanma
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"{ftpServer}/{remoteFilePath}");
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

                // FTP'ye yüklenecek dosyanın içeriğini belirleme
                byte[] fileContents;
                using (StreamReader sourceStream = new StreamReader(localFilePath))
                {
                    fileContents = System.Text.Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                }

                // FTP sunucusuna dosyayı yazma
                request.ContentLength = fileContents.Length;
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(fileContents, 0, fileContents.Length);
                }

                // İşlemi tamamlama
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == FtpStatusCode.CommandOK)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static string UploadFileToFtp(IFormFile formFile, string ftpPath)
        {
            //// FTP bağlantı bilgileri
            //string ftpServer = "ftp://example.com";
            //string ftpUsername = "yourUsername";
            //string ftpPassword = "yourPassword";

            //// Yükleyeceğiniz dosyanın yolu
            //string localFilePath = @"C:\Path\To\Your\File.txt";

            //// FTP'de kaydedilecek dosyanın yolu ve adı
            //string remoteFilePath = "/public_html/yourfile.txt";

            //// FTP'ye dosya yükleme işlemi
            //UploadFileToFtp(ftpServer, ftpUsername, ftpPassword, localFilePath, remoteFilePath);

            try
            {
                FtpSettingViewModel ftpSettingViewModel = ConfigurationHelper.GetFtpSettings();
                // FTP'ye bağlanma
                string fileExtension = Path.GetExtension(formFile.FileName);
                string fileName = Guid.NewGuid().ToString() + fileExtension;
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"{ftpSettingViewModel.Server}//{ftpSettingViewModel.Domain}//{ftpPath}//{fileName}");
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(ftpSettingViewModel.UserName, ftpSettingViewModel.Password);

                // FTP'ye yüklenecek dosyanın içeriğini belirleme
                byte[] fileContents;


                using (StreamReader sourceStream = new StreamReader(formFile.OpenReadStream()))
                {
                    fileContents = System.Text.Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                }

                // FTP sunucusuna dosyayı yazma
                request.ContentLength = fileContents.Length;
                using (Stream requestStream = request.GetRequestStream())
                {
                    formFile.CopyTo(requestStream);
                    //requestStream.Write(fileContents, 0, fileContents.Length);
                }

                // İşlemi tamamlama
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    Console.WriteLine($"Dosya yüklendi. Sunucu cevabı: {response.StatusDescription}");
                }

                return $"{ftpSettingViewModel.Domain}/{ftpPath}/{fileName}";
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
