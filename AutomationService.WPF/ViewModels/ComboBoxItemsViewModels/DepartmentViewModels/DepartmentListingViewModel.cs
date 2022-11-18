using AutomationService.Domain.Models.Common;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.BreakdownViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AutomationService.WPF.ViewModels.ComboBoxItemsViewModels.DepartmentViewModels;

public class DepartmentListingViewModel : ViewModelBase
{
    readonly ObservableCollection<DepartmentListingItemViewModel> _departmentListingItemViewModels;
    readonly DepartmentStore _departmentStore;

    public IEnumerable<DepartmentListingItemViewModel> DepartmentListingItemViewModels => _departmentListingItemViewModels;

    public DepartmentListingViewModel(BreakdownDetailsFormViewModel breakdownDetailsFormViewModel, DepartmentStore departmentStore)
    {
        _departmentStore = departmentStore;
        _departmentListingItemViewModels = new ObservableCollection<DepartmentListingItemViewModel>();

        DepartmentStore_DepartmentStoreLoaded();
    }

    private void DepartmentStore_DepartmentStoreLoaded()
    {
        _departmentListingItemViewModels.Clear();
        foreach (Department department in _departmentStore.Departments)
        {
            AddDepartment(department);
        }
    }

    private void AddDepartment(Department department)
    {
        DepartmentListingItemViewModel itemViewModel = new DepartmentListingItemViewModel(department);

        _departmentListingItemViewModels.Add(itemViewModel);
    }
}
