using HRMSproject1.Repository.Interfaces;
using HRMSproject1.Repository.Models;
using HRMSproject1.Repository.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSproject1.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MyContext myContext;
        public EmployeeRepository(MyContext context)
        {
            myContext = context;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await myContext.Employees.ToListAsync();    
        }

        public async Task<Employee> InsertEmployee(Employee emp)
        {
            var result = await myContext.AddAsync(emp);
            await myContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<List<DeptEmp>> GetEmployeesDetails(int? DeptId)
        {
            var result = await myContext.DeptEmployees.FromSqlRaw("exec GetEmpDetails {0}", DeptId).ToListAsync();
            return result;
        }
    }
}
