using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM.Data.Interfaces;
using HRM.Entity;
using HRM.Entity.DevAccessory;

namespace HRM.Data
{
    public class EmployeeSalaryRepository : Repository<EmployeeSalary>, IEmployeeSalaryRepository
    {
        //override
        //public bool Update(EmployeeSalary updated, int key)
        //{

        //    Debug.Assert(context != null);
        //    Debug.Assert(updated != null);

        //    try
        //    {
        //        EmployeeSalary existing = context.Set<EmployeeSalary>().Find(key);
        //        if (existing != null)
        //        {
        //            context.Entry(existing).CurrentValues.SetValues(updated);
        //        }
        //        return context.SaveChanges() > 0;
        //    }
        //    catch (Exception e)
        //    {
        //        Output.Write("Error in data update : \n" + e);
        //        return false;
        //    }
        //}
        override
        public bool Update(EmployeeSalary updated, int key)
        {

            Debug.Assert(context != null);
            Debug.Assert(updated != null);

            try
            {
                EmployeeSalary existing = context.Set<EmployeeSalary>().Find(key);
                if (existing != null)
                {
                    context.Entry(existing).CurrentValues.SetValues(updated);
                }
                return context.SaveChanges() > 0;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {

                    Output.Write("Entity of type \"" + eve.Entry.Entity.GetType().Name +
                        "\"  in state \"" + eve.Entry.State + "\" has the following validation errors:");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Output.WriteLine("- Property: \"" + ve.PropertyName + "\", Error: \"" + ve.ErrorMessage + "\"");
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Output.WriteLine("Error in data update : " + e);
                return false;
            }
        }
    }
}
