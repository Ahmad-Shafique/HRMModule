using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Service.Interfaces
{
    public interface IDomainService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get<Tkey>(Tkey id);
        Task<bool> Insert(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> RemoveByKey<TKey>(TKey id);
        Task<bool> RemoveByEntity(TEntity entity);
    }
}
