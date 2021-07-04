using AliErguc.Blog.Business.Interfaces;
using AliErguc.Blog.DataAccess.Interfaces;
using AliErguc.Blog.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AliErguc.Blog.Business.Concrete
{
    public class CategoryManager : GenericManager<Category>, ICategoryServices
    {
        private readonly IGenericDal<Category> _genericDal;
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(IGenericDal<Category> genericDal, ICategoryDal categoryDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _categoryDal = categoryDal;
        }

  
        public async Task<List<Category>> GetAllSortedByAsync()
        {
            return await _genericDal.GetAllAsync(I=>I.Id);
        }

        public async Task<List<Category>> getAllWithCategoryBlogsAsync()
        {
            return await _categoryDal.getAllWithCategoryBlogsAsync();
        }
    }
}
