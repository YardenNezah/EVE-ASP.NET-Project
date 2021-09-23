using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVE.Models
{
    public class Cart
    {
        //Cart Values:
        public int CartID { get; set; }
        public int MemberID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
