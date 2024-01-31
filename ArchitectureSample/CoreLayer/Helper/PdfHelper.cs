using CoreLayer.Entity.ViewModel.FileViewModel;
using SelectPdf;

namespace CoreLayer.Helper
{
    public static class PdfHelper
    {
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
