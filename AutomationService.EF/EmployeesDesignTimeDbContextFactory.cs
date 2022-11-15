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
                .UseSqlServer("Server=YAZILIM-ORKUN\\SQLEXPRESS;Database=AutomationServiceDB; User Id=sa; Password=1q2w3e4r; Encrypt=False; Trusted_Connection=True;")
                .Options);
        }
    }
}
