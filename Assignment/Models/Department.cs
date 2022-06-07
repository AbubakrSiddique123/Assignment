﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

    }
}
