using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEFProject.ViewModels
{
    public class DeptEmp
    {
        private int deptId;
        private int deptId1;

        public int GetDeptId()
        {
            return deptId1;
        }

        public void SetDeptId(int value)
        {
            deptId1 = value;
        }

        public string DeptName { get; set; }
        public string DeptLocation { get; set; }
        public int EmpId { get; set; }
        public int DeptId { get => deptId; set => deptId = value; }
        public string EmpName { get; set; }
        public decimal EmpSalary { get; set; }
    }
}