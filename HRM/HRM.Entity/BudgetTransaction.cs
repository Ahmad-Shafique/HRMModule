using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class BudgetTransaction
    {
        [Key]
        public int BudgetTransactionId { get; set; }
        public int MonthlyBudgetId { get; set; }
        public string Type { get; set; } // Type can be salary, training, project, hiring, other
        public int TypeId { get; set; } // SalaryId, TrainingId etc. any Id
        public int Amount { get; set; }
        public string Description { get; set; }

    }
}
