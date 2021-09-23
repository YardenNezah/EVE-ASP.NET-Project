using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVE.Models
{
    public class Transaction
    {
        //Transactions Values:
        public int TransactionID { get; set; }
        public int MemberID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public string ApprovalStatus { get; set; }
    }
}
