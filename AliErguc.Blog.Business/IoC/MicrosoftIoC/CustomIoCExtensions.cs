using AliErguc.Blog.Business.Concrete;
using AliErguc.Blog.Business.Interfaces;
using AliErguc.Blog.Business.Utilities.JwtUtil;
using AliErguc.Blog.Business.ValidationRules.FluentValidation;
using AliErguc.Blog.DataAccess.Concrete.EFCore.Repositories;
using AliErguc.Blog.DataAccess.Interfaces;
using AliErguc.Blog.Dto.AppUserDtos;
using AliErguc.Blog.Dto.CategoryBlogDtos;
using AliErguc.Blog.Dto.CategoryDtos;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliErguc.Blog.Business.IoC.MicrosoftIoC
{
    public static class CustomIoCExtensions
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(EFGenericRepository<>));
            services.AddScoped(typeof(IGenericServices<>), typeof(GenericManager<>));
            services.AddScoped<IBlogServices, BlogManager>();
            services.AddScoped<IBlogDal, EFBlogRepository>();

            services.AddScoped<ICategoryServices, CategoryManager>();
            services.AddScoped<ICategoryDal, EFCategoryRepository>();

            services.AddScoped<IAppUserServices, AppUserManager>();
            services.AddScoped<IAppUserDal, EFAppUserRepository>();

            services.AddScoped<ICommentServices, CommentManager>();
            services.AddScoped<ICommentDal, EFCommentRepository>();

            services.AddScoped<IAppUserServices, AppUserManager>();
            services.AddScoped<IAppUserDal, EFAppUserRepository>();

            services.AddScoped<IJwtServices, JwtManager>();

            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginValidator>();
            services.AddTransient<IValidator<CategoryAddDto>, CategoryAddValidator>();
            services.AddTransient<IValidator<CategoryBlogDto>, CategoryBlogValidator>();
            services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateValidator>();


        }
    }
}
