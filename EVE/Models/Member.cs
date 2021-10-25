using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EVE.Models
{
    //Users types
    public enum UserType
    {
        Member,
        Admin

    }
    public class Member
    {
        //Member Values:
        [Key]
        public int MemberID { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Fullname { get; set; }
        [Required]
        public string Address { get; set; }
        [Phone]
        [Required]
        public string Phone { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public string Birthdate { get; set; }
        public UserType Type { get; set; } = UserType.Member;
    }
}
