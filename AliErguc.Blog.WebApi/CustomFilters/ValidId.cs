using AliErguc.Blog.Business.Interfaces;
using AliErguc.Blog.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliErguc.Blog.WebApi.CustomFilters
{
    public class ValidId<TEntity> : IActionFilter where TEntity : class, ITable, new()
    {
        private readonly IGenericServices<TEntity> _genericServices;
        public ValidId(IGenericServices<TEntity> genericServices)
        {
            _genericServices = genericServices;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var dictionary = context.ActionArguments.Where(I => I.Key == "id").FirstOrDefault();

            var id = int.Parse(dictionary.Value.ToString());

            var entity = _genericServices.FindByIdAsync(id).Result;

            if (entity == null)
            {
                context.Result = new NotFoundObjectResult($"{id} değerine sahip nesne bulunamadı.");
            }

        }
    }
}
