using HRM.Data.Interfaces;
using HRM.Data.Utilities;
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
    class WorkDayRepository : Repository<WorkDay>, IWorkDayRepository
    {

        override
        public bool Insert(WorkDay entity)
        {
            //Debug.Assert(context != null);
            //Debug.Assert(entity != null);

            try
            {
                Output.WriteLine("Year of date is entity is: " + entity.StartTime.Year + " : " + entity.EndTime.Year);
                Output.Write(entity.EndTime.Date);
                if (entity.EndTime == new CheckRange().GetMinimumDateRange())
                {
                    List<WorkDay> workDays = this.GetAll().ToList();
                    List<WorkDay> l1, l2, l3;
                    Output.Write("Number of entries in workdays: " + workDays.Count);
                    workDays = workDays.Where(e => e.EmployeeId == entity.EmployeeId).ToList();
                    Output.Write("Number of entries in workdays for selected employee: " + workDays.Count);
                    workDays = workDays.Where(e => e.StartTime.Month == DateTime.Now.Month).ToList();
                    Output.Write("Number of entries in workdays for selected employee this month: " + workDays.Count);
                    workDays = workDays.Where(e => e.StartTime.Day == DateTime.Now.Day).ToList();
                    Output.Write("Number of entries in workdays for selected employee this month this day: " + workDays.Count);
                    if (workDays.Count == 0)
                    {
                        try
                        {
                            context.WorkDays.Add(entity);
                            return context.SaveChanges() > 0;
                        }
                        catch (Exception e)
                        {
                            Output.Write(e);
                            return false;
                        }


                        //return base.Insert(entity);

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
