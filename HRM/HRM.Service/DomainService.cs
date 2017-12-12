using HRM.Data;
using HRM.Data.Interfaces;
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
        protected internal IRepository<TEntity> repository;

        public DomainService()
        {
            repository = new RepositoryFactory().Create<TEntity>();
        }

        public virtual async Task<bool> Insert(TEntity entity)
        {
            return await repository.Insert(entity);
        }

        public virtual async Task<bool> Update(TEntity entity)
        {
            return await repository.Update(entity);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await repository.GetAll();
        }

        public virtual async Task<TEntity> Get<Tkey>(Tkey id)
        {
            return await repository.Get(id);
        }

        public async Task<bool> RemoveByKey<TKey>(TKey id)
        {
            return await repository.RemoveByKey(id);
        }

        public async Task<bool> RemoveByEntity(TEntity entity)
        {
            return await repository.RemoveByEntity(entity);
        }
    }
}
