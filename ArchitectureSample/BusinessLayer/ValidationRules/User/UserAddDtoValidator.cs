using CoreLayer.IoC;
using DataAccessLayer.Absctract;
using EntityLayer.Dto.User.Request;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.ValidationRules.User
{
    public class UserAddDtoValidator : AbstractValidator<UserAddRequestDto>
    {
        public UserAddDtoValidator()
        {
            IValidationRuleDal? validationRuleDal = ServiceTool.ServiceProvider.GetService<IValidationRuleDal>();
            if (validationRuleDal is not null)
            {
                var validationRules = validationRuleDal.Queryable().Where(x => x.ValidatorName == this.GetType().Name );

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
