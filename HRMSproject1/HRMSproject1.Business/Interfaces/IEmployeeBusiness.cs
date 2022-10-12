using HRMSproject1.Models;
using HRMSproject1.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSproject1.Business.Interfaces
{
    public interface IEmployeeBusiness
    {
       Task <List<EmployeeVM>> GetAllEmployees();
       Task<EmployeeVM> InsertEmployee(EmployeeVM emp);

        Task<List<DeptEmpVM>> GetEmployeesDetails(int? DeptId);
    }
}
