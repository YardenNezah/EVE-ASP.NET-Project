using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EVE.Models
{
    public class Product
    {
        //Products Values:
        [Key]
        public int ProductID { get; set; } // private key

        [Required]
        [Display(Name = "Product")]
        public String ProductName { get; set; }

        public int ProductTypeId { get; set; } // forgein key

        [Display(Name = "Product Type")]
        public ProductType ProductType { get; set; } // one to meny

        [MaxLength(1500)]
        public String Description { get; set; }

        [Range(1, 1000)]
        public int Stock { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }

        public String ImageSource { get; set; }

        public String FrontImage { get; set; }

        public String BackImage { get; set; }

        public IList<Comment> Comments { get; set; }
    }

}

