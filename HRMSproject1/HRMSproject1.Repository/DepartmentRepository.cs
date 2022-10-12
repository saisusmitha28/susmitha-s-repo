using HRMSproject1.Repository.Interfaces;
using HRMSproject1.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSproject1.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly MyContext myContext;
        public DepartmentRepository(MyContext _myContext)
        {
            myContext = _myContext;
        }   
    }
}
