using AliErguc.Blog.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliErguc.Blog.Entities.Concrete
{
    public class Category : ITable
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public List<CategoryBlog> CategoryBlogs { get; set; }
    }
}
