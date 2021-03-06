using AliErguc.Blog.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliErguc.Blog.Entities.Concrete
{
    public class BlogSection : ITable
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public DateTime PostedTime { get; set; } = DateTime.Now;
        public string ImagePath { get; set; }

        public List<CategoryBlog> CategoryBlogs { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
