using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EVE.Models
{
    public class Cart
    {
        //Cart Values:
        [Key]
        public int Id { get; set; }

        public int Memberid { get; set; }

        public Member Member { get; set; }

        public IList<Product> Products { get; set; }

        public int Quantity { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Total")]
        public double TotalPrice { get; set; }
    }
}
