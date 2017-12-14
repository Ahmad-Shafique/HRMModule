using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class EquipmentTransaction
    {
        [Key]
        public int EquipmentTransactionId { get; set; }
        public string TransactionType { get; set; }
        public int TransactionAmount { get; set; }
        public string InvolvedPartType { get; set; }
        public int ReceivingPartyId { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
