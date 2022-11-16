using AutomationService.WPF.ViewModels;
using AutomationService.WPF.ViewModels.BreakdownViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.HostBuilders
{
    public static class AddViewModelsHostBuilderExtension
    {
        public static IHostBuilder AddViewModels(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<MainViewModel>();
                services.AddTransient<BreakdownsViewModel>();
            });

            return hostBuilder;
        }
    }
}
