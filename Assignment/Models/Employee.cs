using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(30)]
        public string FatherName { get; set; }

        public int? DesignationID { get; set; }

        public int? DepartmentID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? JoiningDate { get; set; }

        public int? Salary { get; set; }

        public bool? IsActive { get; set; }

        public  Department Department { get; set; }
        public  Designation Designation { get; set; }

    }
}
