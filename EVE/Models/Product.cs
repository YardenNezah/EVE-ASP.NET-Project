using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

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

        public Byte[] Image1 { get; set; }

        [NotMapped]
        public IFormFile FrontImage { get; set; }

        public Byte[] Image2 { get; set; }

        [NotMapped]
        public IFormFile BackImage { get; set; }

        public IList<Comment> Comments { get; set; }
    }

}

