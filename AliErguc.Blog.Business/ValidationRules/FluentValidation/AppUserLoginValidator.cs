using AliErguc.Blog.Dto.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliErguc.Blog.Business.ValidationRules.FluentValidation
{
    public class AppUserLoginValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginValidator()
        {
            RuleFor(I => I.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez.");
            RuleFor(I => I.Password).NotEmpty().WithMessage("Parola Alanı Boş Geçilemez.");
        }
    }
}
