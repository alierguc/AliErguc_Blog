using AliErguc.Blog.WebUI.ApiServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliErguc.Blog.WebUI.ViewComponents
{
    public class CategoryList:ViewComponent
    {
        private readonly ICategoryApiServices _categoryApiServices;
        public CategoryList(ICategoryApiServices categoryApiServices)
        {
            _categoryApiServices = categoryApiServices;
        }
        public IViewComponentResult Invoke()
        {
            return View(_categoryApiServices.GetAllCategoryList().Result);
        }
    }
}
