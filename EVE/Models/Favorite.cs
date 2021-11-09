using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVE.Models
{
    public class Favorite
    {
        //Favorite Values:
        public int Id { get; set; }

        public int Memberid { get; set; }

        public Member Member { get; set; }

        public IList<Product> Products { get; set; }

        public int Quantity { get; set; }

        public double TotalPrice { get; set; }
    }
}
