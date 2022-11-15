using AutomationService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.Domain.Commands.BreakdownCommands
{
    public interface ICreateBreakdownCommand
    {
        Task Create(Breakdown breakdown);
    }
}
