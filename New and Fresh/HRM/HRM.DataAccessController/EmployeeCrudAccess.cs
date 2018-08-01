using HRM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.DataAccessController
{
    class EmployeeCrudAccess<TEntity> : BaseCrudAccess<TEntity> where TEntity:class
    {
        public override bool Insert(TEntity entity)
        {
            if (typeof(TEntity) != typeof(LeaveApplication)) return true;
            return repository.Insert(entity);
        }

        public override bool Update(TEntity entity, int key)
        {
            if(typeof(TEntity) == typeof(LeaveApplication))
            {
                return repository.Update(entity, key);
            }
            else if(typeof(TEntity) == typeof(EmployeeBio))
            {
                return repository.Update(entity, key);
            }
            return true;
            
        }

        public override IEnumerable<TEntity> GetAll()
        {
            if(typeof(TEntity) == typeof(CompanyPolicy)) return repository.GetAll();
            return new List<TEntity>();
        }

        public override TEntity Get<Tkey>(Tkey id)
        {
            if (typeof(TEntity) == typeof(LeaveApplication))
            {
                return repository.Get(id);
            }
            else if (typeof(TEntity) == typeof(EmployeeBio))
            {
                return repository.Get(id);
            }
            return CreateInstance();
        }

        public override bool RemoveByEntity(TEntity entity)
        {
            return true;
        }




        // https://stackoverflow.com/questions/6717516/return-a-new-instance-rather-than-a-null-instance-in-generics
        private TEntity CreateInstance()
        {
            System.Reflection.ConstructorInfo constructor = (typeof(TEntity)).GetConstructor(System.Type.EmptyTypes);
            if (ReferenceEquals(constructor, null))
            {
                //there is no default constructor
                return default(TEntity);
            }
            else
            {
                //there is a default constructor
                //you can invoke it like so:
                return (TEntity)constructor.Invoke(new object[0]);
                //return constructor.Invoke(new object[0]) as T; //If T is class
            }
        }
    }
}
