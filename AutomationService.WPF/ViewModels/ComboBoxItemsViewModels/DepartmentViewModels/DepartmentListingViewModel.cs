using AutomationService.Domain.Models.Common;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.BreakdownViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AutomationService.WPF.ViewModels.ComboBoxItemsViewModels.DepartmentViewModels;

public class DepartmentListingViewModel : ViewModelBase
{
    readonly DepartmentStore _departmentStore;

    public IEnumerable<DepartmentListingItemViewModel> DepartmentListingItemViewModels => _departmentStore._departmentListingItemViewModels;

    public DepartmentListingViewModel(BreakdownDetailsFormViewModel breakdownDetailsFormViewModel, DepartmentStore departmentStore)
    {
        _departmentStore = departmentStore;
    }




}
