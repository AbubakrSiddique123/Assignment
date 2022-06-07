using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Models
{
    public class Designation
    {
        [Key]
        public int DesignationId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        
    }
}
