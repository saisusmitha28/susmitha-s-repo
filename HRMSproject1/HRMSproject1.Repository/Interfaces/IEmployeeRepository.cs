using HRMSproject1.Repository.Models;
using HRMSproject1.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSproject1.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        Task <List<Employee>>GetAllEmployees();
        Task<Employee> InsertEmployee(Employee e);

        Task<List<DeptEmp>> GetEmployeesDetails(int? DeptId);
    }
}
