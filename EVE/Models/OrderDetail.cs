using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EVE.Models
{
    public enum OrderStatus
    {
        Canceled,
        Processing,
        Shipped,
        Delivered,
        Returned
    }
    public class OrderDetail
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public Member Member { get; set; }

        [DisplayName("Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime OrderDate { get; set; }

        public IList<Product> Products { get; set; }

        [Required]
        [DisplayName("Items")]
        public int NumOfItem { get; set; }

        [Required]
        [DisplayName("Price")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")] 
        public decimal Price { get; set; }

        [DisplayName("Order status")]
        public OrderStatus Status { get; set; }
    }
}
