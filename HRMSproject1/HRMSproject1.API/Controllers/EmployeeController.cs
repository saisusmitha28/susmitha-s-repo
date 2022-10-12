using HRMSproject1.Business.Interfaces;
using HRMSproject1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMSproject1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBusiness _empBusiness;
        public EmployeeController(IEmployeeBusiness empBusiness)
        {
            _empBusiness = empBusiness;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _empBusiness.GetAllEmployees();
            return Ok(employees);

        }
        [HttpPost]
        public async Task<IActionResult> PostEmployee(EmployeeVM emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(emp);
            }
            var result = await _empBusiness.InsertEmployee(emp);
            if (result is not null)
            {
                return Ok();
            }
            else
            {
                return NotFound(result);
            }
        }
        // [Route("api/Employee/EmployeeDetailsByDeptId")]
        [HttpGet]
        public async Task<ActionResult> GetEmployeesDetails(int? DeptId = null)
        {
            var result = await _empBusiness.GetEmployeesDetails(DeptId);
            return Ok(result);
        }
    }
}
