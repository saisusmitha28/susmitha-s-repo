using AutoMapper;
using HRMSproject1.Business.Interfaces;
using HRMSproject1.Models;
using HRMSproject1.Repository.Interfaces;
using HRMSproject1.Repository.Models;
using HRMSproject1.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSproject1.Business
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IEmployeeRepository _empRepository;
        private readonly IMapper _mapper;

        public EmployeeBusiness(IEmployeeRepository empRepository, IMapper mapper)
        {
            _empRepository = empRepository;
            _mapper = mapper;

        }

        public async Task<List<EmployeeVM>> GetAllEmployees()
        {
            var employees = await _empRepository.GetAllEmployees();
            return _mapper.Map<List<EmployeeVM>>(employees);
            //  List<EmployeeVM> emps = new List<EmployeeVM>();
            // foreach (var emp in employees)
            // {
            // EmployeeVM e = new EmployeeVM()
            //{
            // DeptId = emp.DeptId,
            // EmpId = emp.EmpId,
            // EmpName = emp.EmpName,
            //EmpSalary = emp.EmpSalary
            // };
            //  emps.Add(e);
            // }
        }



        public async Task<EmployeeVM> InsertEmployee(EmployeeVM emp)
        {
           
            var result = await _empRepository.InsertEmployee(_mapper.Map<Employee>(emp));
            return _mapper.Map<EmployeeVM>(result);
            
        }

        public async Task<List<DeptEmpVM>> GetEmployeesDetails(int? DeptId)
        {
            var result = await _empRepository.GetEmployeesDetails(DeptId);
            return _mapper.Map<List<DeptEmpVM>>(result);
        }

    }
}
