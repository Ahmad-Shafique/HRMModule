using HRM.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Data
{
    public abstract class Reposatory<TEntity> : IReposatory<TEntity> where TEntity : class
    {
        internal HRMDbContext context = new HRMDbContext();
        public virtual bool Insert(TEntity entity)
        {
            context.Set<TEntity>().Add(entity); //or, context.Entry<TEntity>(entity).State = EntityState.Added;
            return context.SaveChanges() > 0;
        }

        public virtual bool Update(TEntity entity)
        {
            context.Entry<TEntity>(entity).State = EntityState.Modified;
            return context.SaveChanges() > 0;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public virtual TEntity Get<TKey>(TKey id)
        {
            return context.Set<TEntity>().Find(id);
        }  
    }
}
