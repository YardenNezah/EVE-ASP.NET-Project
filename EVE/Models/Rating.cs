using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVE.Models
{
    public class Rating
    {
        //Rating Values:
        public int RatingID { get; set; }
        public int MemberID { get; set; }
        public int ProductID { get; set; }
        public int Value { get; set; } //The popularity hierarchry (X/The total num of products)
    }
}
