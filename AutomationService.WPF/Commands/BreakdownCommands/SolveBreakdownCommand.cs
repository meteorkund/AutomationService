using AutomationService.Domain.Models;
using AutomationService.Domain.Models.Common;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.BreakdownViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.Commands.BreakdownCommands
{
    public class SolveBreakdownCommand : AsyncCommandBase
    {
        private SolveBreakdownViewModel _solveBreakdownViewModel;
        private BreakdownStore _breakdownStore;
        readonly ModalNavigationStore _modalNavigationStore;


        public SolveBreakdownCommand(SolveBreakdownViewModel solveBreakdownViewModel, BreakdownStore breakdownStore, ModalNavigationStore modalNavigationStore)
        {
            _solveBreakdownViewModel = solveBreakdownViewModel;
            _breakdownStore = breakdownStore;
            _modalNavigationStore = modalNavigationStore;
        }


        public override async Task ExecuteAsync(object parameter)
        {
            SolveBreakdownFormViewModel formViewModel = _solveBreakdownViewModel.SolveBreakdownFormViewModel;

            formViewModel.ErrorMessage = null;
            formViewModel.ErrorMessage = null;

            DateTime solvedDate;
            if (formViewModel.CurrentBreakdown.Status == true)
                solvedDate = DateTime.Now;
            else
                solvedDate = formViewModel.CurrentBreakdown.SolvedDate;



                Breakdown breakdown = new Breakdown
                {
                    Id = _solveBreakdownViewModel.BreakdownId,
                    DepartmentId = formViewModel.CurrentBreakdown.Department.Id,
                    SectorId = formViewModel.CurrentBreakdown.Sector.Id,
                    CustomerId = formViewModel.CurrentBreakdown.Customer.Id,
                    EmployeeId = formViewModel.CurrentBreakdown.Employee.Id,

                    BreakdownSolverId = formViewModel.SelectedBreakdownSolverItem.BreakdownSolverId,

                    Status = false,

                    Department = new Department(
                            formViewModel.CurrentBreakdown.Department.Id,
                            formViewModel.CurrentBreakdown.Department.DepartmentName),

                    Sector = new Sector(
                            formViewModel.CurrentBreakdown.Sector.Id,
                            formViewModel.CurrentBreakdown.Sector.SectorName),

                    Customer = new Customer(
                            formViewModel.CurrentBreakdown.Customer.Id,
                            formViewModel.CurrentBreakdown.Customer.CompanyName,
                            formViewModel.CurrentBreakdown.Customer.Country),

                    Employee = new Employee(
                            formViewModel.CurrentBreakdown.Employee.Id,
                            formViewModel.CurrentBreakdown.Employee.NameSurname),

                    BreakdownSolver = new BreakdownSolver(
                            formViewModel.SelectedBreakdownSolverItem.BreakdownSolver.Id,
                            formViewModel.SelectedBreakdownSolverItem.BreakdownSolver.NameSurname),

                    IsElectrical = formViewModel.CurrentBreakdown.IsElectrical,
                    IsMechanical = formViewModel.CurrentBreakdown.IsMechanical,

                    Cause = formViewModel.CurrentBreakdown.Cause,
                    Service = formViewModel.Service,

                    CreatedDate = formViewModel.CurrentBreakdown.CreatedDate,
                    SolvedDate = solvedDate
                };

            try
            {
                await _breakdownStore.Update(breakdown);
                _modalNavigationStore.Close();
            }
            catch
            {
                formViewModel.ErrorMessage = "Arıza kapatma sırasında hata oluştu.";
                formViewModel.ErrorMessageTryLater = "Daha sonra tekrar deneyiniz.";
            }
            finally
            {
                formViewModel.IsSubmitting = false;

            }
        }
    }
}
