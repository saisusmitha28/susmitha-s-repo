using HRMSproject1.Business.Interfaces;
using HRMSproject1.Repository.Interfaces;
using HRMSproject1.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSproject1.Business
{
    public class DepartmentBusiness : IDepartmentBusiness
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentBusiness(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
    }
}
