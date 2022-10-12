using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSproject1.Models
{
    public class DeptEmpVM
    {
        public int EmpId { get; set; }
        public int DeptId { get; set; }
        public string EmpName { get; set; }
        public decimal EmpSalary { get; set; }
        public string DeptName { get; set; }
        public string DeptLocation { get; set; }
    }
}
