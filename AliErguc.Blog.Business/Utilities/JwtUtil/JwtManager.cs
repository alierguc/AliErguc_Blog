using AliErguc.Blog.Core.Constants;
using AliErguc.Blog.Entities.Concrete;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AliErguc.Blog.Business.Utilities.JwtUtil
{
    public class JwtManager : IJwtServices
    {
        public JwtToken GenerateJwt(AppUser appUser)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(JwtInfo.SECURITY_KEY));

            SigningCredentials signingCredentials = new SigningCredentials
                (securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer:JwtInfo.ISSUER,
                audience:JwtInfo.AUDIENCE,claims: SetClaims(appUser),
                notBefore:DateTime.Now,
                expires:DateTime.Now.AddMinutes(JwtInfo.EXPIRES),
                signingCredentials: signingCredentials);

            JwtToken jwtToken = new JwtToken();
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            jwtToken.token = handler.WriteToken(jwtSecurityToken);
            return jwtToken;
        }

        private List<Claim> SetClaims(AppUser appUser)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, appUser.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString()));
            return claims;
        }
    }
}
