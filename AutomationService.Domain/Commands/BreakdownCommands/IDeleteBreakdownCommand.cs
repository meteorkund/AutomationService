using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.Domain.Commands.BreakdownCommands
{
    public interface IDeleteBreakdownCommand
    {
        Task DeleteBreakdown(Guid id);
    }
}
