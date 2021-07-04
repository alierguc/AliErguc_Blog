using AliErguc.Blog.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliErguc.Blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IBlogServices _blogService;
        public ImagesController(IBlogServices blogService)
        {
            _blogService = blogService;
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> getBlogImageById(int id)
        {
            try
            {
            var blog = await _blogService.FindByIdAsync(id);
            if (string.IsNullOrWhiteSpace(blog.ImagePath))
            {
                return NotFound("Resim Yok");
            }
            return File($"/img/{blog.ImagePath}","image/jpeg");
            }
            catch
            {
                return NotFound("İlgili Resim bulunamadı");
            }
        }
    }
}
