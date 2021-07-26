using AliErguc.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AliErguc.Blog.DataAccess.Interfaces
{
    public interface IBlogDal : IGenericDal<BlogSection>
    {
        Task<List<BlogSection>> GetAllByCategoryId(int _categoryId);
    }
}
