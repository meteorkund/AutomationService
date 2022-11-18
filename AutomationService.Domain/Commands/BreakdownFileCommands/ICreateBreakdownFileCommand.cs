using AutomationService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.Domain.Commands.BreakdownFileCommands
{
    public interface ICreateBreakdownFileCommand
    {
        Task CreateBreakdownFile(BreakdownFile breakdownFile);
    }
}
