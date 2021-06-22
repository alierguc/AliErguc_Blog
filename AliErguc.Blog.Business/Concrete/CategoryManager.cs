using AliErguc.Blog.Business.Interfaces;
using AliErguc.Blog.DataAccess.Interfaces;
using AliErguc.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AliErguc.Blog.Business.Concrete
{
    public class CategoryManager : GenericManager<Category>, ICategoryServices
    {
        private readonly IGenericDal<Category> _genericDal;
        public CategoryManager(IGenericDal<Category> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task<List<Category>> GetAllSortedBy()
        {
            return await _genericDal.GetAllAsync(I=>I.Id);
        }
    }
}
