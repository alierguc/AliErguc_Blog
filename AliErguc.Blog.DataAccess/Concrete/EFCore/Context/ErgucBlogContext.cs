using AliErguc.Blog.Core.Constants;
using AliErguc.Blog.DataAccess.Concrete.EFCore.MapConfiguring;
using AliErguc.Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliErguc.Blog.DataAccess.Concrete.EFCore.Context
{
    public class ErgucBlogContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.DB_INFO);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new BlogMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new CategoryBlogMap());
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Category> Categories { get; set; } 
        public DbSet<CategoryBlog> CategoryBlogs { get; set; } 
        public DbSet<Comment> Comments { get; set; } 
        public DbSet<BlogSection> BlogSection { get; set; } 
    }
}
