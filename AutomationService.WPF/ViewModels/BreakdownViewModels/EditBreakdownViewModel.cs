using AutomationService.Domain.Models;
using AutomationService.EF.DTOs;
using AutomationService.WPF.Commands;
using AutomationService.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomationService.WPF.ViewModels.BreakdownViewModels
{
    public class EditBreakdownViewModel : ViewModelBase
    {
        public int BreakdownId { get; }
        public BreakdownDetailsFormViewModel BreakdownDetailsFormViewModel { get; }

        public EditBreakdownViewModel(Breakdown breakdown, BreakdownStore breakdownStore, ModalNavigationStore modalNavigationStore)
        {
            BreakdownId = breakdown.Id;

            ICommand submitCommand = new EditBreakdownCommand(this, breakdownStore, modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            BreakdownDetailsFormViewModel = new BreakdownDetailsFormViewModel(submitCommand, cancelCommand)
            {
                Department = breakdown.Department,
                Sector = breakdown.Sector,
                //Cause = customer.Breakdown.Cause,
                //Service = customer.Breakdown.Service,
                //CreatorName = customer.Employee.NameSurname,

            };
        }
    }
}
