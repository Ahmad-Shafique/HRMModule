using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class CompanyPolicy
    {
        [Key]
        public int CompanyPolicyId { get; set; }
        public string PolicyName { get; set; }
        public string PolicyDescription { get; set; }
    }
}
