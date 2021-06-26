using AliErguc.Blog.Business.Interfaces;
using AliErguc.Blog.DataAccess.Interfaces;
using AliErguc.Blog.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AliErguc.Blog.Business.Concrete
{
    public class GenericManager<TableEntity> : IGenericServices<TableEntity> where TableEntity : class,ITable, new()
    {
        private readonly IGenericDal<TableEntity> _genericDal;

        public GenericManager(IGenericDal<TableEntity> genericDal)
        {
            _genericDal = genericDal;
        }
        public async Task AddAsync(TableEntity _entity)
        {
             await _genericDal.AddAsync(_entity);
        }

        public async Task<TableEntity> FindByIdAsync(int _id)
        {
            return await _genericDal.FindByIdAsync(_id);
        }

        public async Task<List<TableEntity>> GetAllAsync()
        {
            return await _genericDal.GetAllAsync();
        }


        public async Task RemoveAsync(TableEntity _entity)
        {
            await _genericDal.RemoveAsync(_entity);
        }

        public async Task UpdateAsync(TableEntity _entity)
        {
            await _genericDal.UpdateAsync(_entity);
        }
    }
}
