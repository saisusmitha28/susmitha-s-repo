using HRMSproject1.Repository.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSproject1.Repository.Models
{
    public class MyContext : SnadDataContext
    {
        public MyContext()
        {
        }

        public MyContext(DbContextOptions<SnadDataContext> options)
            : base(options)
        {
        }
        public virtual DbSet<DeptEmp> DeptEmployees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeptEmp>(entity => entity.HasNoKey());
            base.OnModelCreating(modelBuilder);
        }
    }
   
}
