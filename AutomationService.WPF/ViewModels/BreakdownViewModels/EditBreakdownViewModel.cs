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
        public Guid BreakdownId { get; }
        public DateTime CreatedDate { get; }
        public DateTime UpdatedDate { get; }
        public BreakdownDetailsFormViewModel BreakdownDetailsFormViewModel { get; }

        public EditBreakdownViewModel(Breakdown breakdown, BreakdownStore breakdownStore, ModalNavigationStore modalNavigationStore, BreakdownSolverStore breakdownSolverStore, DepartmentStore departmentStore, SectorStore sectorStore, EmployeeStore employeeStore, CustomerStore customerStore)
        {
            BreakdownId = breakdown.Id;
            CreatedDate = breakdown.CreatedDate;
            UpdatedDate = breakdown.UpdatedDate;


            ICommand submitCommand = new EditBreakdownCommand(this, breakdownStore, modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);


            BreakdownDetailsFormViewModel = new BreakdownDetailsFormViewModel(submitCommand, cancelCommand, breakdownSolverStore, departmentStore, sectorStore, employeeStore, customerStore)
            {

                IsElectrical = breakdown.IsElectrical,
                IsMechanical = breakdown.IsMechanical,
                Cause = breakdown.Cause,

                SelectedDepartmentValue = breakdown.Department.Id,
                SelectedSectorValue = breakdown.Sector.Id,
                SelectedEmployeeValue = breakdown.Employee.Id,
                SelectedCompanyValue = breakdown.Customer.Id,
                SelectedCountryValue = breakdown.Customer.Id,
            };
        }
    }
}
