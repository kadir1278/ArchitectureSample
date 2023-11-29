using CoreLayer.IoC;
using DataAccessLayer.Absctract;
using EntityLayer.Dto.User;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.User
{
    public class UserAddDtoValidator : AbstractValidator<UserAddDto>
    {
        public UserAddDtoValidator()
        {
            IValidationRuleDal? validationRuleDal = ServiceTool.ServiceProvider.GetService<IValidationRuleDal>();
            if (validationRuleDal is not null)
            {
                var validationRules = validationRuleDal.Queryable().Where(x => x.ValidatorName == this.GetType().Name && x.IsActive);

                var userNameNotEmpty = validationRules.FirstOrDefault(y => y.Key.Equals("Username.NotEmpty"));
                if (userNameNotEmpty is not null)
                    RuleFor(x => x.Username).NotEmpty().WithMessage(userNameNotEmpty.Message);
                else
                    RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");

                var userNameMinLength = validationRules.FirstOrDefault(y => y.Key.Equals("Username.MinLength"));
                if (userNameMinLength is not null)
                    RuleFor(x => x.Username).MinimumLength(Convert.ToInt32(userNameMinLength.Value)).WithMessage(userNameMinLength.Message);
                else
                    RuleFor(x => x.Username).MinimumLength(8).WithMessage("Kullanıcı adı en az 8 karakter olmalı");
            }
        }
    }
}
