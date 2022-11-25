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
            var connectionString = $"DataSource=\\\\Desktop-1pm23j9\\testing\\arizaData.db";

            return new AutomationServiceDBContext(new DbContextOptionsBuilder()
                .UseSqlite(connectionString)
                .Options);
        }
    }
}
