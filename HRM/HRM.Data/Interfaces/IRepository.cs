using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM.Data.Interfaces;
using HRM.Entity;

namespace HRM.Data.Interfaces
{
    public interface IRepository <TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get<Tkey>(Tkey id);
        Task<bool> Insert(TEntity entity);
        Task<bool> Update(TEntity entity, int key);
        //Task<bool> RemoveByKey<TKey>(TKey id);
        Task<bool> RemoveByEntity(TEntity entity);

    }
}
