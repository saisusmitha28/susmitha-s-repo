using AutoMapper;
using HRMSproject1.Models;
using HRMSproject1.Repository.Models;
using HRMSproject1.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSproject1.Utilities
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<EmployeeVM, Employee>().ReverseMap();
            CreateMap<DeptEmpVM, DeptEmp>().ReverseMap();
            CreateMap<DepartmentVM, Department>().ReverseMap();
        }

    }
}
