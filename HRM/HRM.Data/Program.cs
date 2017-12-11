using HRM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Data
{
    class Program
    {
        static void Main()
        {
            HRMDbContext ctx = new HRMDbContext();
            ctx.LeaveApplicationCategories.Add(new LeaveApplicationCategory()
            {
                LeaveApplicationCategoryName = "test"
            });
        }
    }
}
