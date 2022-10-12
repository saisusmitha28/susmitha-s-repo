using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSproject1.Models
{
    public class EmployeeVM
    {
        public int EmpId { get; set; }
        [Required(ErrorMessage ="Dept Id is Mandatory")]
        public int DeptId { get; set; }
        [Required(ErrorMessage = "Employee Name is Mandatory")]
        [MaxLength(6,ErrorMessage ="Max Length is 6 Characters")]
        public string EmpName { get; set; }
        [Required(ErrorMessage = "Employee Salary is Mandatory")]
        public decimal EmpSalary { get; set; }

    }
}
