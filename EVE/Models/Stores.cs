using System;
using System.ComponentModel.DataAnnotations;

namespace EVE.Controllers
{
    public class Stores
    {
        [Key]
        public int Id { get; set; }
        public string name;
        public string phone;
        public string countrey { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string houseNumber { get; set; }
    }
}
