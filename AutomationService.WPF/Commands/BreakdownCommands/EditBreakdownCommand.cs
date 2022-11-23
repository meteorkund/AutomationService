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
        formViewModel.ErrorMessageTryLater = null;
        formViewModel.IsSubmitting = true;

        bool isStatusTrue = true;
        if (formViewModel.BreakdownStatus == false)
            isStatusTrue = false;
        

        Breakdown breakdown = new Breakdown
        {


            Id = _editBreakdownViewModel.BreakdownId,

            Status = isStatusTrue,

            DepartmentId = formViewModel.SelectedDepartmentValue,
            SectorId = formViewModel.SelectedSectorValue,
            CustomerId = formViewModel.SelectedCompanyValue,
            EmployeeId = formViewModel.SelectedEmployeeValue,
            BreakdownSolverId = formViewModel.SelectedEmployeeValue,


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


            IsElectrical = formViewModel.IsElectrical,
            IsMechanical = formViewModel.IsMechanical,

            Cause = formViewModel.Cause,

            CreatedDate = _editBreakdownViewModel.CreatedDate,
        };

        try
        {
            await _breakdownStore.Update(breakdown);

}
        catch (Exception)
        {
            formViewModel.ErrorMessage = "Arıza güncelleme sırasında hata oluştu.";
            formViewModel.ErrorMessageTryLater = "Daha sonra tekrar deneyiniz.";
        }
        finally
{
    formViewModel.IsSubmitting = false;
}
    }
}
