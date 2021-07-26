using AliErguc.Blog.Dto.CategoryBlogDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliErguc.Blog.Business.ValidationRules.FluentValidation
{
    public class CategoryBlogValidator : AbstractValidator<CategoryBlogDto>
    {
        public CategoryBlogValidator()
        {
            RuleFor(I => I.BlogId).InclusiveBetween(0, int.MaxValue).WithMessage("Blog Id Boş Geçilemez");
            RuleFor(I => I.CategoryId).InclusiveBetween(0, int.MaxValue).WithMessage("Category Id Boş Geçilemez");
        }
    }
}
