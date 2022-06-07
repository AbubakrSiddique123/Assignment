using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(8)]
        public string Password { get; set; }
    }
}
