using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.DataAccessController.Interfaces
{
    public interface IBaseCrudAccess<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get<Tkey>(Tkey id);
        bool Insert(TEntity entity);
        bool Update(TEntity entity, int key);
        //bool> RemoveByKey<TKey>(TKey id);
        bool RemoveByEntity(TEntity entity);
    }
}
