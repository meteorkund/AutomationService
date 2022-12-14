using AutomationService.Domain.Queries;
using AutomationService.Domain.Queries.BreakdownFileQueries;
using AutomationService.Domain.Queries.BreakdownSolverQueries;
using AutomationService.Domain.Queries.BrekdownQueries;
using AutomationService.Domain.Queries.CustomerQueries;
using AutomationService.Domain.Queries.EmployeeQueries;
using AutomationService.EF.Queries;
using AutomationService.EF.Queries.BreakdownFileQueries;
using AutomationService.EF.Queries.BreakdownQueries;
using AutomationService.EF.Queries.BreakdownSolverQueries;
using AutomationService.EF.Queries.CustomerQueries;
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

                services.AddSingleton<IGetAllBreakdownSolverQuery, GetAllBreakdownSolverQuery>();
                services.AddSingleton<IGetAllDepartmentsQuery, GetAllDepartmentsQuery>();
                services.AddSingleton<IGetAllSectorsQuery, GetAllSectorsQuery>();

                services.AddSingleton<IGetAllCustomersQuery, GetAllCustomersQuery>();


            });

            return hostBuilder;
        }
    }
}
