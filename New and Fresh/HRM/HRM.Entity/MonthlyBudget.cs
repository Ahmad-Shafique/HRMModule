using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class MonthlyBudget
    {
        [Key]
        public int MonthlyBudgetId { get; set; }
        public DateTime BudgetPeriod { get; set; }
        public int TotalAmountAllocated { get; set; }
        public int TotalSalaryEpenditure { get; set; }
        public int TotalTrainingExpenditure { get; set; }
        public int TotalProjectExpenditure { get; set; }
        public int TotalHiringExpenditure { get; set; }
        public int OverAllExpenditure { get; set; }
    }
}
