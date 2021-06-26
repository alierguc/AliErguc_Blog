﻿using AliErguc.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AliErguc.Blog.Business.Interfaces
{
    public interface IBlogServices : IGenericServices<BlogSection>
    {
        Task<List<BlogSection>> GetAllSortedByPostedTimeAsync();
    }
}
