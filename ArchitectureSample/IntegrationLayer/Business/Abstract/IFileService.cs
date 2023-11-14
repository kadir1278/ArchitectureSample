using CoreLayer.Entity.ViewModel.FileViewModel;
using CoreLayer.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;

namespace IntegrationLayer.Business.Abstract
{
    public interface IFileService
    {
        string ConvertBase64ToFile(string fileName, string fileType, string fileBase64, string uploadPath);
        public IDataResult<DownloadFileViewModel> DownloadToZipFilePath(string filePath);

        string CreateToIFormFile(IFormFile formFile, string uploadPath);
    }
}
