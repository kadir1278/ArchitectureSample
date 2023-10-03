namespace CoreLayer.Entity.ViewModel.FileViewModel
{
    public class DownloadFileViewModel
    {
        public MemoryStream File { get; set; }
        public string? FileName { get; set; }
        public string ContentType { get; set; }
    }
}
