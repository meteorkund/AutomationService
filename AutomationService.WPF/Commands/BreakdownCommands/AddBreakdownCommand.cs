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
        readonly BreakdownStore _breakdownStore;
        readonly AddBreakdownViewModel _addBreakdownViewModel;
        readonly AutomationServiceDBContextFactory _contextFactory;

        int lastBreakdownId;
        public AddBreakdownCommand(AddBreakdownViewModel addBreakdownViewModel, BreakdownStore breakdownStore, ModalNavigationStore modalNavigationStore, AutomationServiceDBContextFactory contextFactory)
        {
            _modalNavigationStore = modalNavigationStore;
            _breakdownStore = breakdownStore;
            _addBreakdownViewModel = addBreakdownViewModel;
            _contextFactory = contextFactory;

        }

        public override async Task ExecuteAsync(object parameter)
        {
            BreakdownDetailsFormViewModel formViewModel = _addBreakdownViewModel.BreakdownDetailsFormViewModel;

            formViewModel.ErrorMessage = null;




            Breakdown breakdown = new Breakdown
            {
                Id = Guid.NewGuid(),
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

                BreakdownSolver = new BreakdownSolver(
                    formViewModel.SelectedBreakdownSolverItem.BreakdownSolverId,
                    formViewModel.SelectedBreakdownSolverItem.NameSurname),

                Customer = new Customer(
                    formViewModel.SelectedCompanyItem.CustomerId, 
                    formViewModel.SelectedCompanyItem.CompanyName, 
                    formViewModel.SelectedCountryItem.Country),

                IsElectrical = formViewModel.IsElectrical,
                IsMechanical = formViewModel.IsMechanical,

                Cause = formViewModel.Cause,
                Service = formViewModel.Service,

                 CreatedDate = DateTime.Now,


            };




            try
            {
                await _breakdownStore.Add(breakdown);


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
