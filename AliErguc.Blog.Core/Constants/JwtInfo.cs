using System;
using System.Collections.Generic;
using System.Text;

namespace AliErguc.Blog.Core.Constants
{
    public class JwtInfo
    {
        public const string ISSUER = "http://localhost:49383";
        public const string AUDIENCE = "http://localhost:5000";
        public const string SECURITY_KEY = "aliergucblogdelikurt";
        public const double EXPIRES = 40;
    }
}
