using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCEFProject.Models;
using MVCEFProject.ViewModels;

namespace MVCEFProject.Controllers
{
    
    public class HomeController : Controller
    {
        SnadDataEntities context = new SnadDataEntities();
        public ActionResult Index()
        {
            //context.Configuration.LazyLoadingEnabled = false;
            context.Configuration.ProxyCreationEnabled = false;
            context.Configuration.LazyLoadingEnabled = false;

            List<Employee> employees = context.Employees.Include("Department").ToList();

            Employee emp = (from a in context.Employees where a.EmpId == 1 select a).SingleOrDefault(); //LINQ
            emp = context.Employees.Where(x => x.EmpId == 1).SingleOrDefault(); //LAMBDA

            string EmpName = (from a in context.Employees where a.EmpId == 1 select a.EmpName).SingleOrDefault();
            EmpName = context.Employees.Where(x => x.EmpId == 1).Select(x => x.EmpName).SingleOrDefault();

            List<Employee> list = (from a in context.Employees where a.DeptId == 1 select a).ToList();
            list = context.Employees.Where(x => x.DeptId == 1).ToList();

            decimal maxSalary = context.Employees.Max(x => x.EmpSalary);
            decimal minSalary = context.Employees.Min(x => x.EmpSalary);
            decimal totalSalary = context.Employees.Sum(x => x.EmpSalary);

            //employees = context.Employees.OrderBy(x => x.EmpSalary).ToList();
            //employees = context.Employees.OrderByDescending(x => x.EmpSalary).ToList();

            var empList = (from a in context.Employees
                           join b in context.Departments on a.DeptId equals b.DeptId
                           select new DeptEmp
                           {
                               DeptId = a.DeptId,
                               DeptName = b.DeptName,
                               DeptLocation = b.DeptLocation,
                               EmpId = a.EmpId,
                               EmpName = a.EmpName,
                               EmpSalary = a.EmpSalary
                           }).ToList();


            return View(employees);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            emp.EmpId = 0;
            context.Employees.Add(emp); //in memory commit
            context.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Details(int id)
        {
            var emp = context.Employees.Where(x => x.EmpId == id).SingleOrDefault();
            return View(emp);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var emp = context.Employees.Where(x => x.EmpId == id).SingleOrDefault();
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            context.Entry(emp).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Delete(int id)
        {
            var emp = context.Employees.Where(x => x.EmpId == id).SingleOrDefault();
            context.Employees.Remove(emp);
            context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}