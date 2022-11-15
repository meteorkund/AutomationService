using AutomationService.EF.DTOs;
using AutomationService.EF.DTOs.Common;
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
        public DbSet<BreadownFileDTO> BreadownFiles { get; set; }
        public DbSet<EmployeeDTO> Employees { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker : Entityler üzerinden yapılan değişiklerin ya da yeni eklenen verinin yakalanmasını sağlayan propertydir. Update operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlar.

            var datas = ChangeTracker
                 .Entries<BaseDTO>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now,
                    _ => DateTime.Now
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}