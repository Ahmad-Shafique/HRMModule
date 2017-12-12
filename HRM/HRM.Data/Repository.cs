using HRM.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public virtual async Task<bool> Update(TEntity entity)
        {

            Debug.Assert(context != null);

            try
            {

                //context.Entry<TEntity>(entity).State = EntityState.Modified;
                context.Set<TEntity>().Remove(entity);
                bool x = await context.SaveChangesAsync() > 0;
                context.Set<TEntity>().Add(entity);
                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in data update : " + e);
                return false;
            }
        }

        public virtual async Task<bool> RemoveByKey<TKey>(TKey id)
        {
            //Debug.Assert(context != null);
            //Debug.Assert(id != null);
            //Debug.Assert(Get(id) != null);

            //try
            //{
            //    context.Set<TEntity>().Remove(await Get(id));

            //    return await context.SaveChangesAsync() > 0;
            //}
            //catch(Exception e)
            //{
            //    Console.WriteLine("Error in data deletion : " + e);
            //    return false;
            //} 
            return true;
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
