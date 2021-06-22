using AliErguc.Blog.DataAccess.Concrete.EFCore.Context;
using AliErguc.Blog.DataAccess.Interfaces;
using AliErguc.Blog.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AliErguc.Blog.DataAccess.Concrete.EFCore.Repositories
{
    public class EFGenericRepository<TableEntity> : IGenericDal<TableEntity> where TableEntity : class, ITable, new()
    {
        public async Task AddAsync(TableEntity _entity)
        {
            using var context = new ErgucBlogContext();
            await context.AddAsync(_entity);
            await context.SaveChangesAsync();
        }

        public async Task<TableEntity> FindByIdAsync(int _id)
        {
            using var context = new ErgucBlogContext();
            return await context.FindAsync<TableEntity>(_id);
        }

        public async Task<List<TableEntity>> GetAllAsync()
        {
            using var context = new ErgucBlogContext();
            return await context.Set<TableEntity>().ToListAsync();
        }

        public async Task<List<TableEntity>> GetAllAsync(Expression<Func<TableEntity, bool>> _filter)
        {
            using var context = new ErgucBlogContext();
            return await context.Set<TableEntity>().Where(_filter).ToListAsync();
        }

        public async Task<List<TableEntity>> GetAllAsync<TKey>(Expression<Func<TableEntity, bool>> _filter,Expression<Func<TableEntity,TKey>> _keySelector)
        {
            // En Son Yapılan Yorumun En Başta Görülebilmesi İçin OrderByDescending Kullanıyoruz ve GetAllAsync Metodu İle Descent Ediyoruz.
            // Bu Filtre Barındıran, şartlı asenkronik bir metottur.
            using var context = new ErgucBlogContext();
            return await context.Set<TableEntity>().Where(_filter).OrderByDescending(_keySelector).ToListAsync();
        }

        public async Task<List<TableEntity>> GetAllAsync<TKey>(Expression<Func<TableEntity, TKey>> _keySelector)
        {
            // En Son Yapılan Yorumun En Başta Görülebilmesi İçin OrderByDescending Kullanıyoruz ve GetAllAsync Metodu İle Descent Ediyoruz.
            // Bu Filtre Barındırmayan, şartlı asenkronik bir metottur.
            using var context = new ErgucBlogContext();
            return await context.Set<TableEntity>().OrderByDescending(_keySelector).ToListAsync();
        }

        public async Task<TableEntity> GetAsync(Expression<Func<TableEntity, bool>> _getFilter)
        {
            using var context = new ErgucBlogContext();
            return await context.Set<TableEntity>().FirstOrDefaultAsync(_getFilter);
        }

        public async Task RemoveAsync(TableEntity _entity)
        {
            using var context = new ErgucBlogContext();
            context.Remove(_entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TableEntity _entity)
        {
            using var context = new ErgucBlogContext();
            context.Update(_entity);
            await context.SaveChangesAsync();

        }
    }
}
