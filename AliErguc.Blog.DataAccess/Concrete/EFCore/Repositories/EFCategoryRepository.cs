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
    public class EFCategoryRepository : EFGenericRepository<Category>, ICategoryDal
    {
        public async Task<List<Category>> getAllWithCategoryBlogsAsync()
        {
            using var context = new ErgucBlogContext();
            return await context.Categories.OrderByDescending(I=> I.Id).Include(I => I.CategoryBlogs).ToListAsync();
        }
    }
}
