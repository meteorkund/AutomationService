using AutomationService.Domain.Queries.BreakdownFileQueries;
using AutomationService.Domain.Queries.BrekdownQueries;
using AutomationService.Domain.Queries.EmployeeQueries;
using AutomationService.EF.Queries.BreakdownFileQueries;
using AutomationService.EF.Queries.BreakdownQueries;
using AutomationService.EF.Queries.EmployeeQueries;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.HostBuilders
{
    public static class AddQueriesHostBuilderExtension
    {
        public static IHostBuilder AddQueries(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<IGetAllBreakdownsQuery, GetAllBreakdownsQuery>();
                services.AddSingleton<IGetAllBreakdownFilesQuery, GetAllBreakdownFilesQuery>();
                services.AddSingleton<IGetAllEmployeesQuery, GetAllEmployeesQuery>();
            });

            return hostBuilder;
        }
    }
}
