using EntityLayer.Dto.User;
using FluentValidation;
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
            RuleFor(x => x.Username).NotEmpty()
                                    .WithMessage("Kullanıcı Adı Boş Olamaz")
                                    .MinimumLength(6)
                                    .WithMessage("Kullanıcı Adı En Az 6 Karakter Olmalı");

            RuleFor(x => x.ProjectOwnerId).NotEmpty().WithMessage("Bağlı Olduğu Firma Boş Olamaz");
        }
    }
}
