using AliErguc.Blog.DataAccess.Concrete.EFCore.Context;
using AliErguc.Blog.DataAccess.Interfaces;
using AliErguc.Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliErguc.Blog.DataAccess.Concrete.EFCore.Repositories
{
    public class EFBlogRepository : EFGenericRepository<BlogSection>, IBlogDal
    {
        public async Task<List<BlogSection>> GetAllByCategoryId(int _categoryId)
        {
            using var context = new ErgucBlogContext();
            return await context.BlogSection.Join(context.CategoryBlogs, b => b.Id, cb => cb.BlogId,
               (blog, CategoryBlog) => new
               {
                   blog = blog,
                   CategoryBlog = CategoryBlog
               }).Where(I => I.CategoryBlog.CategoryId == _categoryId).Select(I => new BlogSection
               {
                   AppUser = I.blog.AppUser,
                   AppUserId = I.blog.AppUserId,
                   CategoryBlogs = I.blog.CategoryBlogs,
                   Comments = I.blog.Comments,
                   Description = I.blog.Description,
                   Id = I.blog.Id,
                   ImagePath = I.blog.ImagePath,
                   PostedTime = I.blog.PostedTime,
                   ShortDescription = I.blog.ShortDescription,
                   Title = I.blog.Title,
               }).ToListAsync();
        }
    }
}
