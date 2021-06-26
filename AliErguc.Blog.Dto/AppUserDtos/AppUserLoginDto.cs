using AliErguc.Blog.Dto.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliErguc.Blog.Dto.AppUserDtos
{
    public class AppUserLoginDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
