using AliErguc.Blog.Dto.BlogDtos;
using AliErguc.Blog.Dto.CategoryDtos;
using AliErguc.Blog.Entities.Concrete;
using AliErguc.Blog.WebApi.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliErguc.Blog.WebApi.Mapping
{
    public class AutoProfile : Profile
    {
        /// <summary>
        /// DTOS and Entities Convert Mapper
        /// </summary>
        public AutoProfile()
        {
            // Dto Katmanı ve Entities arasında mapping işlemi gereklidir.
            CreateMap<BlogListDtos, BlogSection>();
            CreateMap<BlogSection, BlogListDtos>();
            CreateMap<BlogUpdateModel, BlogSection>();
            CreateMap<BlogAddModel, BlogSection>();
            CreateMap<BlogSection, BlogAddModel>();
            CreateMap<CategoryAddDto, Category>();
            CreateMap<Category, CategoryAddDto>();
            CreateMap<CategoryListDto, Category>();
            CreateMap<Category, CategoryListDto>();
            CreateMap<Category, CategoryListDto>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryUpdateDto>();


        }
    }
}
