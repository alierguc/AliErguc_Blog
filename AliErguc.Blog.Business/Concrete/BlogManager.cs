using AliErguc.Blog.Business.Interfaces;
using AliErguc.Blog.DataAccess.Interfaces;
using AliErguc.Blog.Dto.CategoryBlogDtos;
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
        private readonly IGenericDal<CategoryBlog> _categoryBlogService;
        private readonly IBlogDal _blogDal;
        public BlogManager(IGenericDal<BlogSection> genericDal, 
            IGenericDal<CategoryBlog> categoryBlogService, IBlogDal blogDal) : base(genericDal)
        {
            _blogDal = blogDal;
            _genericDal = genericDal;
            _categoryBlogService = categoryBlogService;
        }

        public async Task AddToCategoryAsync(CategoryBlogDto categoryBlogDto)
        {

            var control = await _categoryBlogService.GetAsync(I => I.CategoryId == categoryBlogDto.CategoryId
         && I.BlogId == categoryBlogDto.BlogId);
            if (control == null)
            {
                await _categoryBlogService.AddAsync(new CategoryBlog
                {
                    BlogId = categoryBlogDto.BlogId,
                    CategoryId = categoryBlogDto.CategoryId

                });
            }
        }

        public async Task<List<BlogSection>> GetAllByCategoryIdAsync(int _categoryId)
        {
            return await _blogDal.GetAllByCategoryId(_categoryId);
        }

        public async Task<List<BlogSection>> GetAllSortedByPostedTimeAsync()
        {
            return await _genericDal.GetAllAsync(I => I.PostedTime);
        }

        public async Task RemoveToCategoryAsync(CategoryBlogDto categoryBlogDto)
        {
            var deletedCategoryBlog = await _categoryBlogService.GetAsync(I => I.CategoryId == categoryBlogDto.CategoryId
            && I.BlogId == categoryBlogDto.BlogId);
            if (deletedCategoryBlog != null)
            {
                await _categoryBlogService.RemoveAsync(deletedCategoryBlog);
            }


        }
    }
}
