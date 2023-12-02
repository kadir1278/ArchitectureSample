using CoreLayer.Entity.ViewModel.FileViewModel;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Helper
{
    public static class FileHelper
    {
        public static string ConvertBase64ToFile(string fileName, string fileType, string fileBase64, string uploadPath)
        {
            byte[] byteArray = Convert.FromBase64String(fileBase64);

            string bytePath = Directory.GetCurrentDirectory() + uploadPath;

            if (!Directory.Exists(bytePath))
                Directory.CreateDirectory(bytePath);

            bytePath += "\\" + fileName + fileType;

            if (!File.Exists(bytePath))
                File.WriteAllBytes(bytePath, byteArray);

            return bytePath;
        }

        public static string CreateToIFormFile(IFormFile formFile, string uploadPath)
        {
            try
            {
                string fileName = formFile.FileName;
                string bytePath = Directory.GetCurrentDirectory() + uploadPath;
                string path = Path.Combine(bytePath, fileName);

                if (!Directory.Exists(bytePath))
                    Directory.CreateDirectory(bytePath);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
                return path;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static DownloadFileViewModel DownloadToZipFilePath(string filePath)
        {
            MemoryStream memory = new MemoryStream();
            try
            {
                string downloadFilePath = filePath + ".zip";

                if (!File.Exists(downloadFilePath))
                    ZipFile.CreateFromDirectory(filePath, downloadFilePath);

                using (var stream = new FileStream(downloadFilePath, FileMode.Open))
                {
                    stream.CopyTo(memory);
                }
                memory.Position = 0;
                return new DownloadFileViewModel()
                {
                    File = memory,
                    ContentType = "application /octet-stream",
                    FileName = "ZIP-" + Guid.NewGuid().ToString().ToUpper().Replace("-", "").Substring(0, 8) + ".zip"
                };
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static DownloadFileViewModel CreateToPDF(string pdfHtmlTemplate)
        {
            try
            {

                var userpdf = new HtmlToPdf();
                string pdfTemplate = pdfHtmlTemplate;
                var pdf = userpdf.ConvertHtmlString(pdfTemplate);
                byte[] pdfBytes = pdf.Save();

                MemoryStream memory = new MemoryStream();
                memory.Write(pdfBytes, 0, pdfBytes.Length);

                return new DownloadFileViewModel()
                {
                    File = memory,
                    ContentType = "application/pdf",
                    FileName = "PDF-" + Guid.NewGuid().ToString().ToUpper().Replace("-", "").Substring(0, 8)
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
