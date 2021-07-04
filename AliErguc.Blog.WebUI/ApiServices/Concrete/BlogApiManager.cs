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
    public class BlogApiManager : IBlogApiServices
    {
        private readonly HttpClient _httpClient;
        public BlogApiManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:49383/api/blogs/");
        }
        public async Task<List<BlogListModel>> GetAllAsync()
        {
            var responseMessage = await _httpClient.GetAsync("getall");
            if (responseMessage.IsSuccessStatusCode)
            {
               return JsonConvert.DeserializeObject<List<BlogListModel>>
                    (await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<BlogListModel> GetByIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"getById/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<BlogListModel>
                    (await responseMessage.Content.ReadAsStringAsync());
            }
            return null;

        }
    }
}
