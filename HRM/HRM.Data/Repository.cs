using HRM.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Data
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal HRMDbContext context = HRMDbContext.GetInstance();

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            Debug.Assert(context != null);

            try
            {
                return (await context.Set<TEntity>().ToListAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in fetching data list : " + e);
                return new List<TEntity>();
            }
            
        }

        public virtual async Task<TEntity> Get<TKey>(TKey id)
        {
            Debug.Assert(context != null);
            Debug.Assert(id != null);

            try
            {
                return (await context.Set<TEntity>().FindAsync(id));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in fetching data : " + e);
                return context.Set<TEntity>().ElementAtOrDefault(Int32.Parse(id.ToString()));
            }
            
        }

        public virtual async Task<bool> Insert(TEntity entity)
        {
            Debug.Assert(context != null);
            Debug.Assert(entity != null);

            try
            {
                context.Set<TEntity>().Add(entity); //or, context.Entry<TEntity>(entity).State = EntityState.Added;
                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public virtual async Task<bool> Update(TEntity updated, int key)
        {

            Debug.Assert(context != null);
            Debug.Assert(updated != null);

            try
            {

                //context.Entry<TEntity>(entity).State = EntityState.Modified;
                TEntity existing = context.Set<TEntity>().FindAsync(key).Result;
                if (existing != null)
                {
                    context.Entry(existing).CurrentValues.SetValues(updated);
                }
                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in data update : " + e);
                return false;
            }
        }


        public virtual async Task<bool> RemoveByEntity(TEntity entity)
        {
            Debug.Assert(context != null);
            Debug.Assert(entity != null);

            try
            {
                context.Set<TEntity>().Remove(entity);
                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in data deletion : " + e);
                return false;
            }

        }


    }
}
