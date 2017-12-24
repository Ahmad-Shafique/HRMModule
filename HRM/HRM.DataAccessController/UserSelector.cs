using HRM.DataAccessController.Interfaces;
using HRM.Entity.Accessory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.DataAccessController
{
    class UserSelector<TEntity> where TEntity : class
    {
        private static UserSelector<TEntity> instance;

        public static UserSelector<TEntity> getinstance()
        {
            if (instance == null)
            {
                instance = new UserSelector<TEntity>();
            }
            return instance;
        }

        private UserSelector()
        {

        }

        public int GetViewDisplayAccessNumber(Token token)
        {
            throw new NotImplementedException();
        }

        public IBaseCrudAccess<TEntity> GetCrudAccess(Token token ) 
        {
            // Return user with appropriate access level 
            throw new NotImplementedException();
        }

        public  IBaseCommonViewAccess GetCommonViewAccess(Token token)
        {
            // Return common view with appropriate access level
            throw new NotImplementedException();
        }
    }
}
