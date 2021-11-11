using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EVE.Models
{
    public class ProductType
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Product Type")]
        public String Name { get; set; }
        public IList<Product> Products { get; set; } // many to one
    }
}
