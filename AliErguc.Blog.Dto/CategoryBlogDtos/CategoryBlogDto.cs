using AliErguc.Blog.Dto.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliErguc.Blog.Dto.CategoryBlogDtos
{
    public class CategoryBlogDto : IDto
    {
        public int CategoryId { get; set; }
        public int BlogId { get; set; }
    }
}
