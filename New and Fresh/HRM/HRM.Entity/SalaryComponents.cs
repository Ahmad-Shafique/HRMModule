using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class SalaryComponents
    {
        [Key]
        public int SalaryComponentsId { get; set; }
        public string ComponentName { get; set; }
        public int ComponentValue { get; set; }
        public string Type { get; set; }
    }
}
