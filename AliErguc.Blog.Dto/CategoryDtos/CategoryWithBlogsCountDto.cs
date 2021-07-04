using AliErguc.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliErguc.Blog.Dto.CategoryDtos
{
    public class CategoryWithBlogsCountDto
    {
        public int BlogsCount { get; set; }
        public Category Category{ get; set; }
    }
}
