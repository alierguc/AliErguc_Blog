using AliErguc.Blog.Business.Interfaces;
using AliErguc.Blog.DataAccess.Interfaces;
using AliErguc.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AliErguc.Blog.Business.Concrete
{
    public class BlogManager : GenericManager<BlogSection>, IBlogServices
    {
        private readonly IGenericDal<BlogSection> _genericDal;
        public BlogManager(IGenericDal<BlogSection> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task<List<BlogSection>> GetAllSortedByPostedTimeAsync()
        {
            return await _genericDal.GetAllAsync(I=>I.PostedTime);
        }
    }
}
