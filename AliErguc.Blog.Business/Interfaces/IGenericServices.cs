using AliErguc.Blog.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AliErguc.Blog.Business.Interfaces
{
    public interface IGenericServices<TableEntity> where TableEntity: class,ITable,new()
    {
        Task<List<TableEntity>> GetAllAsync(); // Tüm Kategorileri Al

        Task<TableEntity> FindById(int _id);
        Task AddAsync(TableEntity _entity); // İlgili Entity'e göre Ekle
        Task UpdateAsync(TableEntity _entity); // İlgili Entity'e göre Güncelle
        Task RemoveAsync(TableEntity _entity); // İlgili Entity'e göre Sil
    }
}
