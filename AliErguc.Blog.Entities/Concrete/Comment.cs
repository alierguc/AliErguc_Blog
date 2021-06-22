using AliErguc.Blog.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliErguc.Blog.Entities.Concrete
{
    public class Comment : ITable
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public string AuthorEmail { get; set; }
        public DateTime PostedTime { get; set; }
        public int? ParentCommentId { get; set; }
        public Comment ParentComment { get; set; }
        public List<Comment> SubComments { get; set; }
        public int BlogId { get; set; }
        public BlogSection Blog { get; set; }

    }
}
