using System.Net.Mail;

namespace CoreLayer.Entity.ViewModel.MailSendViewModel
{
    public class MailServiceViewModel
    {
        public string[] toArray { get; set; }
        public string[]? ccArray { get; set; }
        public bool bodyHtml { get; set; }
        public string body { get; set; }
        public string subject { get; set; }
        public List<Attachment> attachment { get; set; }
    }
}
