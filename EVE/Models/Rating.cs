using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVE.Models
{
    public class Rating
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public Member Member { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int Value { get; set; } //The popularity hierarchry (X/The total num of products)
    }
}
