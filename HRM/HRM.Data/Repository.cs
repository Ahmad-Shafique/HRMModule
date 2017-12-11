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
        internal HRMDbContext context = new HRMDbContext();
        public virtual bool Insert(TEntity entity)
        {
            Debug.Assert(context != null);
            Debug.Assert(entity != null);

            try
            {
                context.Set<TEntity>().Add(entity); //or, context.Entry<TEntity>(entity).State = EntityState.Added;
                return context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public virtual bool Update(TEntity entity)
        {

            Debug.Assert(context != null);

            try
            {
                
                context.Entry<TEntity>(entity).State = EntityState.Modified;
                return context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in data update : " + e);
                return false;
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            Debug.Assert(context != null);

            try
            {
                return context.Set<TEntity>().ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in fetching data  list : " + e);
                return new List<TEntity>();
            }
            
        }

        public virtual TEntity Get<TKey>(TKey id)
        {
            Debug.Assert(context != null);
            Debug.Assert(id != null);

            try
            {
                return context.Set<TEntity>().Find(id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in fetching data : " + e);
                return context.Set<TEntity>().ElementAtOrDefault(Int32.Parse(id.ToString()));
            }
            
        }

        public virtual bool Remove<TKey>(TKey id)
        {
            Debug.Assert(context != null);
            Debug.Assert(id != null);
            Debug.Assert(Get(id) != null);

            try
            {
                context.Set<TEntity>().Remove(Get(id));
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine("Error in data deletion : " + e);
                return false;
            }
            
        }

        public virtual bool Remove(TEntity entity)
        {
            Debug.Assert(context != null);
            Debug.Assert(entity != null);

            try
            {
                context.Set<TEntity>().Remove(entity);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in data deletion : " + e);
                return false;
            }

        }
    }
}
