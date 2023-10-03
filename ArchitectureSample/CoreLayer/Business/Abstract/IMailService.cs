﻿using CoreLayer.Entity.ViewModel.MailSendViewModel;
using CoreLayer.Results.Abstract;

namespace CoreLayer.Business.Abstract
{
    public interface IMailService
    {
        IDataResult<bool> SendMail(MailServiceViewModel mailServiceDto, MailConfigurationViewModel mailConfigurationDto);


    }
}