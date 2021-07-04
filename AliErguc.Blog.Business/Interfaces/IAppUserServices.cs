using AliErguc.Blog.Dto.AppUserDtos;
using AliErguc.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AliErguc.Blog.Business.Interfaces
{
    public interface IAppUserServices : IGenericServices<AppUser>
    {
        Task<AppUser> CheckUserAsync(AppUserLoginDto appUserLoginDto);
        Task<AppUser> FindByNameAsync(string userName);
    }
}
