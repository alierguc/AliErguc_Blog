using AliErguc.Blog.Business.Interfaces;
using AliErguc.Blog.Entities.Concrete;
using AliErguc.Blog.WebApi.CustomFilters;
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
    public class BlogsController : ControllerBase
    {
        private readonly IBlogServices _blogServices;
        public BlogsController(IBlogServices blogServices)
        {
            _blogServices = blogServices;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _blogServices.GetAllSortedByPostedTimeAsync());
        }

        [HttpGet("[action]/{id}")]
        [ValidModel]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _blogServices.FindById(id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateBlog(BlogSection blog)
        {
            await _blogServices.AddAsync(blog);
            return Created("", blog);
        }


        [HttpPut("[action]/{id}")]
        [ValidModel]
        public async Task<IActionResult> UpdateBlog(int id, BlogSection blog)
        {
            if(id == blog.Id)
            {
                return BadRequest();
            }
            await _blogServices.UpdateAsync(blog);
            return Ok();
        }

        [HttpDelete("[action]/{id}")]
        [ValidModel]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _blogServices.RemoveAsync(new BlogSection {Id=id });
            return Ok();
        }

    }
}
