using AliErguc.Blog.Business.Interfaces;
using AliErguc.Blog.Dto.CategoryDtos;
using AliErguc.Blog.Entities.Concrete;
using AliErguc.Blog.WebApi.CustomFilters;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryServices _categoryServices;
        public CategoriesController(IMapper mapper, ICategoryServices categoryServices)
        {
            _mapper = mapper;
            _categoryServices = categoryServices;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<CategoryListDto>>
                (await _categoryServices.GetAllSortedByAsync()));
        }

        [HttpGet("[action]/{id}")]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<List<CategoryListDto>>
                (await _categoryServices.FindByIdAsync(id)));
        }

        [HttpPost("[action]")]
        [Authorize]
        [ValidModel]
        public async Task<IActionResult> CategoryCreate(CategoryAddDto categoryAddDto)
        {
            await _categoryServices.AddAsync(_mapper.Map<Category>(categoryAddDto));
            return Created("",categoryAddDto);
        }


        [HttpPut("[action]/{id}")]
        [Authorize]
        [ValidModel]
        public async Task<IActionResult> CategoryUpdate(int id,CategoryUpdateDto categoryUpdateDto)
        {
            if (id != categoryUpdateDto.Id)
                return BadRequest("Geçersiz Id");
            await _categoryServices.UpdateAsync(_mapper.Map<Category>(categoryUpdateDto));
            return NoContent();
        }

        [HttpDelete("[action]/{id}")]
        [Authorize]
        public async Task<IActionResult> CategoryDelete(int id)
        {
            await _categoryServices.RemoveAsync(new Category { Id = id });
            return NoContent();
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetWithBlogsCount()
        {
            var categories = await _categoryServices.getAllWithCategoryBlogsAsync();
            List<CategoryWithBlogsCountDto> listCategory = new List<CategoryWithBlogsCountDto>();
            foreach (var category in categories)
            {
                CategoryWithBlogsCountDto dto = new CategoryWithBlogsCountDto();
                dto.BlogsCount = category.CategoryBlogs.Count;
                dto.Category = category;

                listCategory.Add(dto);
            }

            return Ok(listCategory);
        }


    }
}
