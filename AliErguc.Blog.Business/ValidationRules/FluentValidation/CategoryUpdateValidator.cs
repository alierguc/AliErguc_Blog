using AliErguc.Blog.Dto.CategoryDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliErguc.Blog.Business.ValidationRules.FluentValidation
{
    public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateValidator()
        {
            RuleFor(I => I.Id).InclusiveBetween(0, int.MaxValue).WithMessage("Id Alanı Boş Geçilemez.");
            RuleFor(I => I.Name).NotEmpty().WithMessage("Ad Alanı Boş Geçilemez.");
        }
    }
}
