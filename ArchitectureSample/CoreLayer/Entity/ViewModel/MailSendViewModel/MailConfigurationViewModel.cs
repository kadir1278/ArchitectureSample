using System.Net;

namespace CoreLayer.Entity.ViewModel.MailSendViewModel
{
    public class MailConfigurationViewModel
    {
        public string from { get; set; }
        public string smtpServer { get; set; }
        public int port { get; set; }
        public string emailAddress { get; set; }
        public string password { get; set; }
        public bool sslEnable { get; set; }
        public bool useDefaultCredentials { get; set; }
        public SecurityProtocolType securityProtocolType { get; set; }
    }
}
