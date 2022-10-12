using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCapp1.Models;


namespace MVCapp1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult Index1()
        {

            return View("sample");
        }
        public ActionResult show()
        {
            Employee emp = new Employee()
            {
                EmpId = 101,
                EmpName = "sai",
                EmpSalary = 65000
            };
            return View(emp);
        }
        public ActionResult DisplayEmployees()
        {
            List<Employee>employees=new List<Employee>();
            Employee e = new Employee()
            {
                EmpId = 101,
                EmpName = "sai",
                EmpSalary = 65000

            };
            employees.Add(e);
            e = new Employee()
            {
                EmpId = 102,
                EmpName = "pravi",
                EmpSalary = 75000

            };
            employees.Add(e);
             e = new Employee() {
                EmpId = 103,
                EmpName = "deepu",
                EmpSalary = 50000

            };
            employees.Add(e);

            return View(employees);
        }
        //data from keyboard user
        public ActionResult EnterData()
        {
            return View();

        }
        public ActionResult DispEmp(Employee emp)
        {
            return View("show",emp);       }
    }
}