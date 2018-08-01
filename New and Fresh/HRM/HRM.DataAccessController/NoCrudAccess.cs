using HRM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.DataAccessController
{
    class NoCrudAccess<TEntity> : BaseCrudAccess<TEntity> where TEntity:class
    {
        public override bool Insert(TEntity entity)
        {
            return true;
        }

        public override bool Update(TEntity entity, int key)
        {
            return true;
        }

        public override IEnumerable<TEntity> GetAll()
        {
            return new List<TEntity>();
        }

        public override TEntity Get<Tkey>(Tkey id)
        {
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
