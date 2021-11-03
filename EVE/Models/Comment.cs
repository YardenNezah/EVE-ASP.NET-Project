using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EVE.Models
{
    public class Comment
    {
        //Comment Values:
        public int CommentID { get; set; }

        [DisplayName("sent by")]
        public Member UserName { get; set; }

        public Product Product { get; set; }

        [MaxLength(30)]
        public String Title { get; set; }

        [MaxLength(2500)]
        public string Message { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
}
