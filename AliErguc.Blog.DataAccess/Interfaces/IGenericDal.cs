using AliErguc.Blog.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AliErguc.Blog.DataAccess.Interfaces
{
    public interface IGenericDal<TableEntity> where TableEntity : class, ITable, new()
    {
        Task<List<TableEntity>> GetAllAsync(); // Tüm Kategorileri Al
        Task<List<TableEntity>> GetAllAsync<TKey>(Expression<Func<TableEntity, bool>> _filter, Expression<Func<TableEntity, TKey>> _keySelector);
        Task<List<TableEntity>> GetAllAsync<TKey>(Expression<Func<TableEntity, TKey>> _keySelector);
        Task<List<TableEntity>> GetAllAsync(Expression<Func<TableEntity, bool>> _filter); // Filtre Aracılığıyla Veri Gelecek
        Task<TableEntity> GetAsync(Expression<Func<TableEntity, bool>> _getFilter); // Filtre Aracılığıyla Veri Gelecek
        Task AddAsync(TableEntity _entity); // İlgili Entity'e göre Ekle
        Task<TableEntity> FindByIdAsync(int _id); 
        Task UpdateAsync(TableEntity _entity); // İlgili Entity'e göre Güncelle
        Task RemoveAsync(TableEntity _entity); // İlgili Entity'e göre Sil

    }
}
