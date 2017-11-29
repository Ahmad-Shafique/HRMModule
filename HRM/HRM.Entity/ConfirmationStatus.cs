using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class ConfirmationStatus
    {
        public int ConfirmationStatusId { get; set; }
        public int NoticeId {get;set;}
        public Notice Notice { get; set; }
        public List<Employee> Employees { get; set; }
        public ConfirmationStatus()
        {
            Employees = new List<Employee>();
        }

    }
}
