using CoreLayer.Entity.ViewModel.MailSendViewModel;
using CoreLayer.Utilities.Results.Abstract;

namespace IntegrationLayer.Business.Abstract
{
    public interface IMailService
    {
        IDataResult<bool> SendMail(MailServiceViewModel mailServiceDto, MailConfigurationViewModel mailConfigurationDto);


    }
}
