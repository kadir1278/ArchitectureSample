using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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

    }
}
