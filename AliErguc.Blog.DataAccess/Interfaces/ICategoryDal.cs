using AliErguc.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AliErguc.Blog.DataAccess.Interfaces
{
    public interface ICategoryDal : IGenericDal<Category>
    {
        Task<List<Category>> getAllWithCategoryBlogsAsync();
    }
}
