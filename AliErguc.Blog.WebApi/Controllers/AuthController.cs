using AliErguc.Blog.Business.Interfaces;
using AliErguc.Blog.Business.Utilities.JwtUtil;
using AliErguc.Blog.Dto.AppUserDtos;
using AliErguc.Blog.WebApi.CustomFilters;
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
    public class AuthController : ControllerBase
    {
        private readonly IAppUserServices _appUserServices;
        private readonly IJwtServices _jwtServices;

        public AuthController(IAppUserServices appUserServices, IJwtServices jwtServices)
        {
            _appUserServices = appUserServices;
            _jwtServices = jwtServices;
        }

        [HttpPost("signIn")]
        [ValidModel]
        public async Task<IActionResult> SignIn(AppUserLoginDto appUserLoginDto)
        {
            try
            {
            var user =  await _appUserServices.CheckUserAsync(appUserLoginDto);
            if(user!=null)
            {
                return Created("", _jwtServices.GenerateJwt(user));
            }
            return BadRequest("Kullanıcı Adı veya Şifre Hatalı");

            }
            catch
            {
                return BadRequest("Belirlenemeyen bir hata oluştu.");
            }

        }

        [HttpGet("[action]/activeUser")]
        [Authorize]
        public async Task<IActionResult> ActiveUser()
        {
           var user = await _appUserServices.FindByNameAsync(User.Identity.Name);
            return Ok(new AppUserDto { Name=user.Name,SurName=user.Surname});
        }
    }
}
