using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVE.Models
{
    public class Comment
    {
        //Comment Values:
        public int CommentID { get; set; }
        public int MemberID { get; set; }
        public int ProductID { get; set; }
        public string Message { get; set; } 
    }
}
