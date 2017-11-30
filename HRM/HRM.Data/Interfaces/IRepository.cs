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
        IEnumerable<TEntity> GetAll();
        TEntity Get<Tkey>(Tkey id);
        bool Insert(TEntity entity);
        bool Update(TEntity entity);
        
    }
}
