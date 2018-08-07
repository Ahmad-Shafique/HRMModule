using HRM.Data.Interfaces;
using HRM.Entity;
using HRM.Entity.DevAccessory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Data
{
    public class WorkDayRepository : Repository<WorkDay>, IWorkDayRepository
    {

        override
        public bool Insert(WorkDay entity)
        {
            //Debug.Assert(context != null);
            //Debug.Assert(entity != null);

            try
            {
                if(entity.EndTime == null)
                {
                    List<WorkDay> workDays = this.GetAll().ToList();
                    Output.Write("Number of entries in workdays: " + workDays.Count);
                    workDays.All(e => e.EmployeeId == entity.EmployeeId);
                    Output.Write("Number of entries in workdays for selected employee: " + workDays.Count);
                    workDays.All(e => e.StartTime.Month == DateTime.Now.Month);
                    Output.Write("Number of entries in workdays for selected employee this month: " + workDays.Count);
                    workDays.All(e => e.StartTime.Day == DateTime.Now.Day);
                    Output.Write("Number of entries in workdays for selected employee this month this day: " + workDays.Count);
                    if (workDays.Count == 0)
                    {
                        return base.Insert(entity);
                        
                    }
                    return false;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

    }
}
