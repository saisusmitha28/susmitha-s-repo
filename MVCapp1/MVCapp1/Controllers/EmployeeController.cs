using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCapp1.Models;
using MVCapp1.ViewModels;

namespace MVCapp1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            Employee e = new Employee()
            {
                EmpId = 101,
                EmpName = "sai",
                EmpSalary = 55000

            };
            Department d = new Department()
            {
                DeptId = 102,
                DeptName = "Developer",
                DeptLoaction = "pune"
            };

            DeptEmp obj = new DeptEmp();
            obj.Department = d;
            obj.Employee = e;
            return View(obj);
        }
    }
}