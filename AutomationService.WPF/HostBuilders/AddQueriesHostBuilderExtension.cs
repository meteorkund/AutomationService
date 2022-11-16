﻿using AutomationService.Domain.Queries.BrekdownQueries;
using AutomationService.EF.Queries.BreakdownQueries;
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
            });

            return hostBuilder;
        }
    }
}