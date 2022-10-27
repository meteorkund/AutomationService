using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.EF
{
    public class EmployeesDesignTimeDbContextFactory : IDesignTimeDbContextFactory<AutomationServiceDBContext>
    {
        public AutomationServiceDBContext CreateDbContext(string[] args)
        {
            return new AutomationServiceDBContext(new DbContextOptionsBuilder()
                .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=AutomationServiceDB;Trusted_Connection=True;")
                .Options);
        }
    }
}
