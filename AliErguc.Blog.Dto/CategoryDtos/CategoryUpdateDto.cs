using AliErguc.Blog.Dto.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliErguc.Blog.Dto.CategoryDtos
{
    public class CategoryUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
