using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Service.Interfaces
{
    public interface IDomainService<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get<Tkey>(Tkey id);
        bool Insert(TEntity entity);
        bool Update(TEntity entity);
        bool RemoveByKey<TKey>(TKey id);
        bool RemoveByEntity(TEntity entity);
    }
}
