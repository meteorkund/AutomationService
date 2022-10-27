using AutomationService.EF.DTOs;
using Microsoft.EntityFrameworkCore;

namespace AutomationService.EF
{
    public class AutomationServiceDBContext : DbContext
    {
        public AutomationServiceDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CustomerDTO> Customers { get; set; }
        public DbSet<BreakdownDTO> Breakdowns { get; set; }
        public DbSet<EmployeeDTO> Employees { get; set; }
        
    }
}