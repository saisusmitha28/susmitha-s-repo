using System;
using System.Collections.Generic;

#nullable disable

namespace HRMSproject1.Repository.Models
{
    public partial class Customer
    {
        public int CustId { get; set; }
        public string CustName { get; set; }
        public decimal CustAmount { get; set; }
    }
}
