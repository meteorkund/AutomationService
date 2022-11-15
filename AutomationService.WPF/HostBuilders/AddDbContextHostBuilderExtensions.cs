using AutomationService.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.HostBuilders
{
    public static class AddDbContextHostBuilderExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((context, services) =>
            {
                string connectionString = "Server=YAZILIM-ORKUN\\SQLEXPRESS;Database=AutomationServiceDB; User Id=sa; Password=1q2w3e4r; Encrypt=False; Trusted_Connection=True;";

                services.AddSingleton<DbContextOptions>(new DbContextOptionsBuilder().UseSqlServer(connectionString).Options);
                services.AddSingleton<AutomationServiceDBContextFactory>();
            });

            return hostBuilder;
        }
    }
}
