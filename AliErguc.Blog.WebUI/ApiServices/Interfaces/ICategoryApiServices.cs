using AliErguc.Blog.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliErguc.Blog.WebUI.ApiServices.Interfaces
{
    public interface ICategoryApiServices
    {
        Task<List<CategoryListModel>> GetAllCategoryList();
    }
}
