using AutomationService.Domain.Models;
using AutomationService.Domain.Models.Common;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.BreakdownViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.Commands;

public class EditBreakdownCommand : AsyncCommandBase
{
    readonly EditBreakdownViewModel _editBreakdownViewModel;
    readonly ModalNavigationStore _modalNavigationStore;
    readonly BreakdownStore _breakdownStore;

    public EditBreakdownCommand(EditBreakdownViewModel editBreakdownViewModel, BreakdownStore breakdownStore, ModalNavigationStore modalNavigationStore)
    {
        _editBreakdownViewModel = editBreakdownViewModel;
        _breakdownStore = breakdownStore;
        _modalNavigationStore = modalNavigationStore;
    }

    public override async Task ExecuteAsync(object parameter)
    {
        BreakdownDetailsFormViewModel formViewModel = _editBreakdownViewModel.BreakdownDetailsFormViewModel;

        formViewModel.ErrorMessage = null;
        //formViewModel.IsSubmitting = true;


        Breakdown breakdown = new Breakdown
        {
            Id = _editBreakdownViewModel.BreakdownId,
            DepartmentId = formViewModel.SelectedDepartmentValue,
            SectorId = formViewModel.SelectedSectorValue,
            CustomerId = formViewModel.SelectedCompanyValue,
            EmployeeId = formViewModel.SelectedEmployeeValue,
            BreakdownSolverId = formViewModel.SelectedEmployeeValue,

            Status = true,

            Department = new Department(
                formViewModel.SelectedDepartmentItem.DepartmentId,
                formViewModel.SelectedDepartmentItem.DepartmentName),

            Sector = new Sector(
                formViewModel.SelectedSectorItem.SectorId,
                formViewModel.SelectedSectorItem.SectorName),

            Customer = new Customer(
                formViewModel.SelectedCompanyItem.CustomerId,
                formViewModel.SelectedCompanyItem.CompanyName,
                formViewModel.SelectedCountryItem.Country),

            Employee = new Employee(
                formViewModel.SelectedEmployeeItem.EmployeeId,
                formViewModel.SelectedEmployeeItem.NameSurname),

            BreakdownSolver = new BreakdownSolver(
                formViewModel.SelectedBreakdownSolverItem.BreakdownSolverId,
                formViewModel.SelectedBreakdownSolverItem.NameSurname),

            IsElectrical = formViewModel.IsElectrical,
            IsMechanical = formViewModel.IsMechanical,

            Cause = formViewModel.Cause,
            Service = formViewModel.Service,

            CreatedDate = _editBreakdownViewModel.CreatedDate,
            UpdatedDate = DateTime.Now,
        };

        try
        {
            await _breakdownStore.Update(breakdown);

        }
        catch (Exception)
        {
            formViewModel.ErrorMessage = "Personel güncelleme sırasında hata oluştu. Daha sonra tekrar deneyiniz.";
        }
        finally
        {
            //formViewModel.IsSubmitting = false;
        }
    }
}
