
using HRM.DataAccessController;
using HRM.DataAccessController.Interfaces;
using HRM.Entity.Accessory;
using HRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Service
{
    public abstract class DomainService<TEntity> : IDomainService<TEntity> where TEntity : class
    {
        protected internal IBaseCrudAccess<TEntity> repository;
        

        public DomainService()
        {
            repository =  UserSelector<TEntity>.Getnstance().GetCrudAccess(ServiceFactory.token);
        }

        public virtual  bool Insert(TEntity entity)
        {
            return  repository.Insert(entity);
        }

        public virtual  bool Update(TEntity entity, int key)
        {
            return  repository.Update(entity,key);
        }

        public virtual  IEnumerable<TEntity> GetAll()
        {
            return  repository.GetAll();
        }

        public virtual  TEntity Get<Tkey>(Tkey id)
        {
            return  repository.Get(id);
        }

        //public  bool> RemoveByKey<TKey>(TKey id)
        //{
        //    return  repository.RemoveByKey(id);
        //}

        public  bool RemoveByEntity(TEntity entity)
        {
            return  repository.RemoveByEntity(entity);
        }
    }
}
