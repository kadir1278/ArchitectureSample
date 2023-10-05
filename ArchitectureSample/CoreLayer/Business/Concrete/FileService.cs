using CoreLayer.Business.Abstract;
using CoreLayer.Entity.ViewModel.FileViewModel;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using System.IO.Compression;

namespace CoreLayer.Business.Concrete
{
    public class FileService : IFileService
    {
        public string ConvertBase64ToFile(string fileName, string fileType, string fileBase64, string uploadPath)
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

        public string CreateToIFormFile(IFormFile formFile, string uploadPath)
        {
            string returnPath;
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
                returnPath = path;
            }
            catch (Exception)
            {
                returnPath = null;
            }

            return returnPath;
        }

        public IDataResult<DownloadFileViewModel> DownloadToZipFilePath(string filePath)
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
                return new SuccessDataResult<DownloadFileViewModel>(new DownloadFileViewModel()
                {
                    File = memory,
                    ContentType = "application /octet-stream",
                    FileName = Guid.NewGuid().ToString().ToUpper().Replace("-", "").Substring(0, 8) + ".zip"
                });
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<DownloadFileViewModel>(ex);
            }

        }
    }
}
