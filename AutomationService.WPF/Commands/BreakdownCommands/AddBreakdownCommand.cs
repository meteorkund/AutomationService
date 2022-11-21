using AutomationService.Domain.Models;
using AutomationService.Domain.Models.Common;
using AutomationService.EF;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.BreakdownViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutomationService.WPF.Commands
{
    public class AddBreakdownCommand : AsyncCommandBase
    {
        readonly ModalNavigationStore _modalNavigationStore;
        readonly BreakdownStore _BreakdownStore;
        readonly AddBreakdownViewModel _addBreakdownViewModel;
        readonly AutomationServiceDBContextFactory _contextFactory;

        int lastBreakdownId;
        public AddBreakdownCommand(AddBreakdownViewModel addBreakdownViewModel, BreakdownStore breakdownStore, ModalNavigationStore modalNavigationStore, AutomationServiceDBContextFactory contextFactory)
        {
            _modalNavigationStore = modalNavigationStore;
            _BreakdownStore = breakdownStore;
            _addBreakdownViewModel = addBreakdownViewModel;
            _contextFactory = contextFactory;

            try
            {
                using (AutomationServiceDBContext context = _contextFactory.Create())
                {
                    var lastBreakdown = context.Breakdowns.Last();
                    lastBreakdownId = lastBreakdown.Id;
                }
            }
            catch
            {
                lastBreakdownId = 0;
            }
        }

        public override async Task ExecuteAsync(object parameter)
        {
            BreakdownDetailsFormViewModel formViewModel = _addBreakdownViewModel.BreakdownDetailsFormViewModel;

            formViewModel.ErrorMessage = null;




            Breakdown breakdown = new Breakdown
            {
                Id = lastBreakdownId + 1,
                Status = true,

                Department = new Department(

                    formViewModel.SelectedDepartmentItem.DepartmentId,
                    formViewModel.SelectedDepartmentItem.DepartmentName
                    ),

                Sector = new Sector(
                    formViewModel.SelectedSectorItem.SectorId,
                    formViewModel.SelectedSectorItem.SectorName),

                Employee = new Employee(
                     formViewModel.SelectedEmployeeItem.EmployeeId,
                     formViewModel.SelectedEmployeeItem.NameSurname),

                BreakdownSolver = new(
                    formViewModel.SelectedBreakdownSolverItem.BreakdownSolverId,
                    formViewModel.SelectedBreakdownSolverItem.NameSurname),

                IsElectrical = formViewModel.IsElectrical,
                IsMechanical = formViewModel.IsMechanical,

                Cause = formViewModel.Cause,
                Service = formViewModel.Service,

                Customer = new Customer(1, formViewModel.CompanyName, formViewModel.Country)


            };




            try
            {
                await _BreakdownStore.Add(breakdown);


                _modalNavigationStore.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                formViewModel.ErrorMessage = "Servis kaydı düzenlenmesi sırasında hata oluştu.\n Daha sonra tekrar deneyiniz.";
            }
            finally
            {
                //formViewModel.IsSubmitting = false;
            }
        }
    }
}
