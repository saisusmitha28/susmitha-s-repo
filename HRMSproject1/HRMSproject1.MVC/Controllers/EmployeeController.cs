using HRMSproject1.Business.Interfaces;
using HRMSproject1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRMSproject1.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeBusiness _empBusiness;
        public EmployeeController(IEmployeeBusiness empBusiness)
        {
            _empBusiness = empBusiness;
        }
        public async Task<IActionResult> Index()
        {
            var List = await _empBusiness.GetAllEmployees();
            return View(List);

        }



        [HttpGet]
        public IActionResult InsertData()
        {
            return View();  
        }
        [HttpPost]  





        //inserting data
        public async Task<ActionResult> InsertData(EmployeeVM emp)
        {
            if(!ModelState.IsValid)
            {
                return View();   
            }
            emp.EmpId = 0;


            var employee=await _empBusiness.InsertEmployee(emp);

            if(employee is not null)
            {
                TempData["Status"] = "Employee Added Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public async Task<ActionResult> GetEmployeesDetails(int? DeptId = null)
        {
            var result = await _empBusiness.GetEmployeesDetails(DeptId);
            return View(result);
        }
    }
}
