﻿using HRM.Data.Interfaces;
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
        //internal HRMDbContext context = HRMDbContext.GetInstance();
        internal HRMDbContext context = new HRMDbContext();

        public virtual  IEnumerable<TEntity> GetAll()
        {
            Debug.Assert(context != null);

            try
            {
                //Console.WriteLine("//////////////****************** ENTERED REPO");
                var LIST =  context.Set<TEntity>().ToList();
                //Console.WriteLine(LIST.Count);
                return ( context.Set<TEntity>().ToList());

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Error in fetching data list : " + e);
                return new List<TEntity>();
            }
            
        }

        public virtual  TEntity Get<TKey>(TKey id)
        {
            Debug.Assert(context != null);
            Debug.Assert(id != null);

            try
            {
                return ( context.Set<TEntity>().Find(id));
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error in fetching data : " + e);
                return context.Set<TEntity>().First();
            }
            
        }

        public virtual  bool Insert(TEntity entity)
        {
            Debug.Assert(context != null);
            Debug.Assert(entity != null);

            try
            {
                context.Set<TEntity>().Add(entity); //or, context.Entry<TEntity>(entity).State = EntityState.Added;
                return  context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        public virtual  bool Update(TEntity updated, int key)
        {

            Debug.Assert(context != null);
            Debug.Assert(updated != null);

            try
            {

                //context.Entry<TEntity>(entity).State = EntityState.Modified;
                TEntity existing = context.Set<TEntity>().Find(key);
                if (existing != null)
                {
                    context.Entry(existing).CurrentValues.SetValues(updated);
                }
                return  context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error in data update : " + e);
                return false;
            }
        }


        public virtual  bool RemoveByEntity(TEntity entity)
        {
            Debug.Assert(context != null);
            Debug.Assert(entity != null);

            try
            {
                context.Set<TEntity>().Remove(entity);
                return  context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error in data deletion : " + e);
                return false;
            }

        }


    }
}
