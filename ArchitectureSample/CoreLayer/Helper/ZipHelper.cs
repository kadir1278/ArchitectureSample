using CoreLayer.Entity.ViewModel.FileViewModel;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Helper
{
    public static class ZipHelper
    {
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

    }
}
