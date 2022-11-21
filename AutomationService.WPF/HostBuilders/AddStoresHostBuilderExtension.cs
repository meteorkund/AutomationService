using AutomationService.WPF.Stores;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.HostBuilders
{
    public static class AddStoresHostBuilderExtension
    {
        public static IHostBuilder AddStores(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<ModalNavigationStore>();

                services.AddSingleton<BreakdownStore>();
                services.AddSingleton<BreakdownFileStore>();
                services.AddSingleton<EmployeeStore>();
                services.AddSingleton<DepartmentStore>();
                services.AddSingleton<SectorStore>();
                services.AddSingleton<BreakdownSolverStore>();
                services.AddSingleton<CustomerStore>();


                services.AddSingleton<SelectedBreakdownStore>();
                services.AddSingleton<SelectedBreakdownFileStore>();

            });

            return hostBuilder;
        }
    }
}
