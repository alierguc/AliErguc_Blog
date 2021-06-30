using AliErguc.Blog.WebUI.ApiServices.Interfaces;
using AliErguc.Blog.WebUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AliErguc.Blog.WebUI.ApiServices.Concrete
{
    public class CategoryApiManager : ICategoryApiServices
    {

        private readonly HttpClient _httpClient;

        public CategoryApiManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:49383/api/Categories/");

        }

        public async Task<List<CategoryListModel>> GetAllCategoryList()
        {

            var responseMessage = await _httpClient.GetAsync("getall");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<CategoryListModel>>
                     (await responseMessage.Content.ReadAsStringAsync());
            }
            return null; throw new NotImplementedException();
        }
    }
}
