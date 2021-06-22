using AliErguc.Blog.DataAccess.Interfaces;
using AliErguc.Blog.Entities.Concrete;
using AliErguc.Blog.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliErguc.Blog.DataAccess.Concrete.EFCore.Repositories
{
    public class EFAppUserRepository : EFGenericRepository<AppUser>,IAppUserDal
    {
    }
}
