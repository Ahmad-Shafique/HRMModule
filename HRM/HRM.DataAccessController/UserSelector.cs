using HRM.Data;
using HRM.DataAccessController.Interfaces;
using HRM.Entity.Accessory;
using HRM.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.DataAccessController
{
    public class UserSelector<TEntity> where TEntity : class
    {
        private static UserSelector<TEntity> instance;

        public static UserSelector<TEntity> Getnstance()
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


        public IBaseCrudAccess<TEntity> GetCrudAccess(Token token ) 
        {
            // Return user with appropriate access level 
            //throw new NotImplementedException();

            return new BaseCrudAccess<TEntity>();
            //if (token.PrivilegeToken == "1") return new EmployeeCrudAccess<TEntity>();
            //return new NoCrudAccess<TEntity>(); 
        }

        public static IBaseCommonViewAccess GetCommonViewAccess(Token token)
        {
            // Return common view with appropriate access level
            //throw new NotImplementedException();


            return new BaseCommonViewAccess();
            //if (token.PrivilegeToken == "1") return new EmployeeCommonViewAccess();
            //return new NoCommonViewAccess();
            
        }

        public static LoginObject Authenticate(int Id, string password)
        {
            return FacadeFactory.GetCommonView().Authenticate(Id, password);
        }
    }
}
