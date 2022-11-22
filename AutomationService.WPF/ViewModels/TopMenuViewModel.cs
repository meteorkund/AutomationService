using AutomationService.Domain.Models.Common;
using AutomationService.EF;
using AutomationService.WPF.Commands;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.BreakdownViewModels;
using AutomationService.WPF.ViewModels.ComboBoxItemsViewModels.DepartmentViewModels;
using AutomationService.WPF.ViewModels.ComboBoxItemsViewModels.EmployeeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomationService.WPF.ViewModels;

public class TopMenuViewModel : ViewModelBase
{
    public ICommand AddBreakdownCommand { get; }
    readonly AutomationServiceDBContextFactory _contextFactory;
    readonly BreakdownListingViewModel _breakdownListingViewModel;
    readonly DepartmentStore _departmentStore;
    public IEnumerable<Department> DepartmentListingItemViewModels => _departmentStore.Departments;

    public TopMenuViewModel(BreakdownListingViewModel breakdownListingViewModel, BreakdownStore breakdownStore, ModalNavigationStore modalNavigationStore, AutomationServiceDBContextFactory contextFactory, BreakdownSolverStore breakdownSolverStore, DepartmentStore departmentStore, SectorStore sectorStore, EmployeeStore employeeStore, CustomerStore customerStore)
    {
        _contextFactory = contextFactory;
        _departmentStore = departmentStore;
        _breakdownListingViewModel= breakdownListingViewModel;

        AddBreakdownCommand = new OpenAddBreakdownCommand(breakdownStore, modalNavigationStore, contextFactory, breakdownSolverStore, departmentStore, sectorStore, employeeStore, customerStore);
    }


    private string _textToFilter = string.Empty;
    public string TextToFilter
    {
        get { return _textToFilter; }
        set
        {
            _textToFilter = value;
            OnPropertyChanged(nameof(TextToFilter));

            _breakdownListingViewModel.EmployeeCollection.Filter = FilterEmployee;

        }
    }


    private bool _isCheckedRadioOpen = true;
    public bool IsCheckedRadioOpen
    {
        get { return _isCheckedRadioOpen; }
        set
        {
            _isCheckedRadioOpen = value;
            OnPropertyChanged(nameof(IsCheckedRadioOpen));
            _breakdownListingViewModel.EmployeeCollection.Filter = FilterEmployee;
        }
    }

    private bool _isCheckedRadioSolved = true;
    public bool IsCheckedRadioSolved
    {
        get { return _isCheckedRadioSolved; }
        set
        {
            _isCheckedRadioSolved = value;
            OnPropertyChanged(nameof(IsCheckedRadioSolved));
            _breakdownListingViewModel.EmployeeCollection.Filter = FilterEmployee;
        }
    }

    private bool _isVisibleCBox;
    public bool IsVisibleCBox
    {
        get { return !_isCheckedAllDepartment; }
        set
        {
            _isVisibleCBox = value;
            OnPropertyChanged(nameof(IsVisibleCBox));
        }
    }


    private bool _isCheckedAllDepartment = true;
    public bool IsCheckedAllDepartment
    {
        get { return _isCheckedAllDepartment; }
        set
        {
            _isCheckedAllDepartment = value;
            OnPropertyChanged(nameof(IsCheckedAllDepartment));
            OnPropertyChanged(nameof(IsVisibleCBox));
            if (_isCheckedAllDepartment == true)
                SelectedDepartmentName = string.Empty;
            _breakdownListingViewModel.EmployeeCollection.Filter = FilterEmployee;
        }
    }

    private Department _selectedDepartment;
    public Department SelectedDepartment
    {
        get { return _selectedDepartment; }
        set
        {
            _selectedDepartment = value;
            SelectedDepartmentName = _selectedDepartment?.DepartmentName;

            _breakdownListingViewModel.EmployeeCollection.Filter = FilterEmployee;

            OnPropertyChanged(nameof(SelectedDepartment));
        }
    }

    private string _selectedDepartmentName;

    public string SelectedDepartmentName
    {
        get { return _selectedDepartmentName; }
        set
        {
            _selectedDepartmentName = value;
            OnPropertyChanged(nameof(SelectedDepartmentName));
        }
    }


    private bool FilterEmployee(object emp)
    {
        var empDetail = emp as BreakdownListingItemViewModel;

        if (IsCheckedAllDepartment == true)
        {
            if (IsCheckedRadioOpen == true && IsCheckedRadioSolved == false)
            {
                return empDetail.Status.Equals(true) && (empDetail.CompanyName.Contains(TextToFilter) || empDetail.Country.Contains(TextToFilter));
            }

            if (IsCheckedRadioSolved == true && IsCheckedRadioOpen == false)
            {
                return empDetail.Status.Equals(false) && (empDetail.CompanyName.Contains(TextToFilter) || empDetail.Country.Contains(TextToFilter));
            }

            if (IsCheckedRadioOpen == true && IsCheckedRadioSolved == true)
            {
                return (empDetail.CompanyName.Contains(TextToFilter) || empDetail.Country.Contains(TextToFilter));
            }

            if (IsCheckedRadioOpen == false && IsCheckedRadioSolved == false)
            {
                return false;
            }
        }

        if (IsCheckedAllDepartment == false)
        {
            if (IsCheckedRadioOpen == true && IsCheckedRadioSolved == false)
            {
                return empDetail.Status.Equals(true)
                    && empDetail.Department.Contains(SelectedDepartmentName)
                    && (empDetail.CompanyName.Contains(TextToFilter) || empDetail.Country.Contains(TextToFilter));
            }

            if (IsCheckedRadioSolved == true && IsCheckedRadioOpen == false)
            {
                return empDetail.Status.Equals(false)
                    && empDetail.Department.Contains(SelectedDepartmentName)
                    && (empDetail.CompanyName.Contains(TextToFilter) || empDetail.Country.Contains(TextToFilter));
            }

            if (IsCheckedRadioOpen == true && IsCheckedRadioSolved == true)
            {
                return empDetail.Department.Contains(SelectedDepartmentName)
                    && (empDetail.CompanyName.Contains(TextToFilter) || empDetail.Country.Contains(TextToFilter));
            }

            if (IsCheckedRadioOpen == false && IsCheckedRadioSolved == false)
            {
                return false;
            }
        }

        return true;
    }


}