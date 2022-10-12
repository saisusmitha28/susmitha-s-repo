using MVCapp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCapp1.ViewModels
{
    public class DeptEmp
    {
        public Employee Employee { get; set; }  
        public Department Department { get; set; } 
    }
}