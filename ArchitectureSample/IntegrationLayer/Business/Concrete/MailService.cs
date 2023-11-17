using CoreLayer.Entity.ViewModel.MailSendViewModel;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using IntegrationLayer.Business.Abstract;
using System.Net;
using System.Net.Mail;

namespace IntegrationLayer.Business.Concrete
{
    public class MailService : IMailService
    {
        public IDataResult<bool> SendMail(MailServiceViewModel mailDto, MailConfigurationViewModel mailConfigurationDto)
        {

            ServicePointManager.SecurityProtocol = mailConfigurationDto.securityProtocolType;
            SmtpClient smtp = new SmtpClient(mailConfigurationDto.smtpServer, mailConfigurationDto.port);
            NetworkCredential AccountInfo = new NetworkCredential(mailConfigurationDto.emailAddress, mailConfigurationDto.password);
            MailMessage message = new MailMessage();
            try
            {
                message.Subject = mailDto.subject;
                message.From = new MailAddress(mailConfigurationDto.from);
                foreach (var to in mailDto.toArray)
                    message.To.Add(new MailAddress(to));

                if (mailDto.ccArray is not null)
                {
                    foreach (var cc in mailDto.ccArray)
                    {
                        if (!String.IsNullOrEmpty(cc))
                            message.CC.Add(new MailAddress(cc));
                    }
                }

                message.IsBodyHtml = mailDto.bodyHtml;
                message.Body = mailDto.body;



                if (mailDto.attachment is not null && mailDto.attachment.Count() > 0)
                {
                    foreach (var item in mailDto.attachment)
                        message.Attachments.Add(item);
                }

                smtp.UseDefaultCredentials = mailConfigurationDto.useDefaultCredentials;
                smtp.Credentials = AccountInfo;
                smtp.EnableSsl = mailConfigurationDto.sslEnable;
                smtp.Send(message);
                return new SuccessDataResult<bool>(true);
            }
            catch (SmtpFailedRecipientsException ex)
            {
                for (int i = 0; i < ex.InnerExceptions.Length; i++)
                {
                    SmtpStatusCode status = ex.InnerExceptions[i].StatusCode;
                    if (status == SmtpStatusCode.MailboxBusy ||
                        status == SmtpStatusCode.MailboxUnavailable)
                    {
                        Thread.Sleep(5000);
                        smtp.Send(message);
                        return new ErrorDataResult<bool>("Mail gönderimi başarısız, 5saniye sonra tekrar denenecek");
                    }
                }
                return new ErrorDataResult<bool>(ex);
            }

            catch (Exception ex)
            {
                return new ErrorDataResult<bool>(ex);
            }
        }
    }
}
