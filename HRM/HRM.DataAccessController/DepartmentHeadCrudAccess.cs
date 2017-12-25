using HRM.Data;
using HRM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.DataAccessController
{
    class DepartmentHeadCrudAccess<TEntity> : BaseCrudAccess<TEntity> where TEntity:class
    {
        protected internal DepartmentHeadCrudAccess()
        {
            repository = new RepositoryFactory().Create<TEntity>();
        }

        public override bool Insert(TEntity entity)
        {
            if (typeof(TEntity) == typeof(EmployeeBio)) repository.Insert(entity);
            else if (typeof(TEntity) == typeof(HireRequest)) repository.Insert(entity);
            return true;
        }

        public override bool Update(TEntity entity, int key)
        {
            if(typeof(TEntity) == typeof(EmployeeBio)) repository.Update(entity, key);
            else if(typeof(TEntity) == typeof(HireRequest)) repository.Update(entity, key);
            return true;
        }

        public override IEnumerable<TEntity> GetAll()
        {
            if(typeof(TEntity) == typeof(CompanyPolicy))return repository.GetAll();

            return new List<TEntity>();
        }

        public override TEntity Get<Tkey>(Tkey id)
        {
            return repository.Get(id);
        }

        public override bool RemoveByEntity(TEntity entity)
        {
            return repository.RemoveByEntity(entity);
        }
    }
}
