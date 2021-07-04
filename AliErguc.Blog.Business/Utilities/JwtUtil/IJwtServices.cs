using AliErguc.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliErguc.Blog.Business.Utilities.JwtUtil
{
    public interface IJwtServices
    {
        JwtToken GenerateJwt(AppUser appUser);
    }
}
