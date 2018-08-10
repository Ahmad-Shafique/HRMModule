using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM.Data.Interfaces;
using HRM.Entity;
using HRM.Entity.DevAccessory;

namespace HRM.Data
{
    class NoticeEmployeeRepository : Repository<NoticeEmployee>, INoticeEmployeeRepository
    {
        override
       public bool Insert(NoticeEmployee entity)
        {
            try
            {

                List<NoticeEmployee> list = this.GetAll().Where(e => e.EmployeeId == entity.EmployeeId
                                                               && e.NoticeId == entity.NoticeId).ToList();
                if(list.Count == 0)
                {
                    try
                    {
                        context.NoticeEmployees.Add(entity);
                        return context.SaveChanges() > 0;
                    }
                    catch (Exception e)
                    {
                        Output.Write(e);
                        return false;
                    }
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
