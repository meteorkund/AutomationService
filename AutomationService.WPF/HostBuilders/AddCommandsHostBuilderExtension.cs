using AutomationService.Domain.Commands.BreakdownCommands;
using AutomationService.Domain.Commands.BreakdownFileCommands;
using AutomationService.EF.Commands.BreakdownCommands;
using AutomationService.EF.Commands.BreakdownFileCommands;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.HostBuilders
{
    public static class AddCommandsHostBuilderExtension
    {
        public static IHostBuilder AddCommands(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<ICreateBreakdownCommand, CreateBreakdownCommand>();
                services.AddSingleton<IUpdateBreakdownCommand, UpdateBreakdownCommand>();
                services.AddSingleton<IDeleteBreakdownCommand, DeleteBreakdownCommand>();

                services.AddSingleton<IDeleteBreakdownFileCommand, DeleteBreakdownFileCommand>();
            });

            return hostBuilder;
        }
    }
}
