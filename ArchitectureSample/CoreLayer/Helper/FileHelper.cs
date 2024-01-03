using CoreLayer.Entity.ViewModel.FileViewModel;
using Microsoft.AspNetCore.Http;
using SelectPdf;
using System.IO.Compression;

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
    }
}
