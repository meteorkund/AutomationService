using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.Domain.Commands.BreakdownFileCommands
{
    public interface IDeleteBreakdownFileCommand
    {
        Task DeleteBreakdownFile(int id);
    }
}
