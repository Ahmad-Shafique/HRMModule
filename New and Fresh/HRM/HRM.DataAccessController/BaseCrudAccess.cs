using HRM.Data;
using HRM.Data.Interfaces;
using HRM.DataAccessController.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.DataAccessController
{
    class BaseCrudAccess<TEntity> : IBaseCrudAccess<TEntity> where TEntity:class
    {
        protected internal IRepository<TEntity> repository;

        protected internal BaseCrudAccess()
        {
            repository = new RepositoryFactory().Create<TEntity>();
        }

        public virtual bool Insert(TEntity entity)
        {
            return repository.Insert(entity);
        }

        public virtual bool Update(TEntity entity, int key)
        {
            return repository.Update(entity, key);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return repository.GetAll();
        }

        public virtual TEntity Get<Tkey>(Tkey id)
        {
            return repository.Get(id);
        }

        public virtual bool RemoveByEntity(TEntity entity)
        {
            return repository.RemoveByEntity(entity);
        }
    }
}
