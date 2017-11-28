using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Data.Interfaces
{
    public interface IReposatory <TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get<Tkey>(Tkey id);
        bool Insert(TEntity entity);
        bool Update(TEntity entity);
        
    }
}
