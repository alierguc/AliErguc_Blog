using AliErguc.Blog.Business.Interfaces;
using AliErguc.Blog.Dto.BlogDtos;
using AliErguc.Blog.Entities.Concrete;
using AliErguc.Blog.WebApi.CustomFilters;
using AliErguc.Blog.WebApi.Enums;
using AliErguc.Blog.WebApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AliErguc.Blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : BaseController
    {
        private readonly IBlogServices _blogServices;
        private readonly IMapper _mapper;
        public BlogsController(IBlogServices blogServices, IMapper mapper)
        {
            _blogServices = blogServices;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok( _mapper.Map<List<BlogListDtos>>(await _blogServices.GetAllSortedByPostedTimeAsync()));
        }

        [HttpGet("[action]/{id}")]
        [ValidModel]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<BlogListDtos>(await _blogServices.FindByIdAsync(id)));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateBlog([FromForm]BlogAddModel blogAddModel)
        {

            var uploadModel = await UploadFileAsync(blogAddModel.Image, "image/jpeg"); 

            if(uploadModel.UploadState == UploadState.Success)
            {
                blogAddModel.ImagePath = uploadModel.NewName;
                await _blogServices.AddAsync(_mapper.Map<BlogSection>(blogAddModel));
                return Created("", blogAddModel);
            }
            else if (uploadModel.UploadState == UploadState.NotExists)
            {
                await _blogServices.AddAsync(_mapper.Map<BlogSection>(blogAddModel));
            }
            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }

            return Created("", blogAddModel);
        }


        [HttpPut("[action]/{id}")]
        [ValidModel]
        public async Task<IActionResult> UpdateBlog(int id, [FromForm] BlogUpdateModel blogUpdateModel)
        {
            if (id != blogUpdateModel.Id)
                return BadRequest("geçersiz id");

            var uploadModel = await UploadFileAsync(blogUpdateModel.Image, "image/jpeg");

            if (uploadModel.UploadState == UploadState.Success)
            {
                var updatedBlog = await _blogServices.FindByIdAsync(blogUpdateModel.Id);

                updatedBlog.ShortDescription = blogUpdateModel.ShortDescription;
                updatedBlog.Title = blogUpdateModel.Title;
                updatedBlog.Description = blogUpdateModel.Description;
                updatedBlog.ImagePath = uploadModel.NewName;


                await _blogServices.UpdateAsync(updatedBlog);
                return NoContent();
            }
            else if (uploadModel.UploadState == UploadState.NotExists)
            {
                var updatedBlog = await _blogServices.FindByIdAsync(blogUpdateModel.Id);
                updatedBlog.ShortDescription = blogUpdateModel.ShortDescription;
                updatedBlog.Title = blogUpdateModel.Title;
                updatedBlog.Description = blogUpdateModel.Description;

                await _blogServices.UpdateAsync(updatedBlog);
                return NoContent();
            }
            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }
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
