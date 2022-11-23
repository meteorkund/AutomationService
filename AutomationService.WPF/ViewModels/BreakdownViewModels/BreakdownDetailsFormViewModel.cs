using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.ComboBoxItemsViewModels.BreakdownSolverViewModels;
using AutomationService.WPF.ViewModels.ComboBoxItemsViewModels.CustomerViewModels;
using AutomationService.WPF.ViewModels.ComboBoxItemsViewModels.DepartmentViewModels;
using AutomationService.WPF.ViewModels.ComboBoxItemsViewModels.EmployeeViewModels;
using AutomationService.WPF.ViewModels.ComboBoxItemsViewModels.SectorViewModels;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace AutomationService.WPF.ViewModels.BreakdownViewModels;

public class BreakdownDetailsFormViewModel : ViewModelBase
{

    readonly BreakdownSolverStore _breakdownSolverStore;
    readonly DepartmentStore _departmentStore;
    readonly SectorStore _sectorStore;
    readonly EmployeeStore _employeeStore;
    readonly CustomerStore _customerStore;

    readonly BreakdownSolverListingViewModel _breakdownSolverListingViewModel;
    readonly DepartmentListingViewModel _departmentListingViewModel;
    readonly SectorListingViewModel _sectorListingViewModel;
    readonly EmployeeListingViewModel _breakdownListingViewModel;
    readonly CustomerListingViewModel _customerListingViewModel;
    public IEnumerable<BreakdownSolverListingItemViewModel> BreakdownSolverListingItemViewModels => _breakdownSolverListingViewModel.BreakdownSolverListingItemViewModels;
    public IEnumerable<DepartmentListingItemViewModel> DepartmentListingItemViewModels => _departmentListingViewModel.DepartmentListingItemViewModels;
    public IEnumerable<SectorListingItemViewModel> SectorListingItemViewModels => _sectorListingViewModel.SectorListingItemViewModels;
    public IEnumerable<EmployeeListingItemViewModel> EmployeeListingItemViewModels => _breakdownListingViewModel.EmployeeListingItemViewModels;

    public IEnumerable<CustomerListingItemViewModel> CountryListing => _customerListingViewModel.CustomerListingItemViewModels;
    public IEnumerable<CustomerListingItemViewModel> CompanyNameListing => _customerListingViewModel.CustomerListingItemViewModels.Where(x => x.Country == SelectedCountry).ToList();




    public BreakdownDetailsFormViewModel(ICommand submitCommand, ICommand cancelCommand, BreakdownSolverStore breakdownSolverStore, DepartmentStore departmentStore, SectorStore sectorStore, EmployeeStore employeeStore, CustomerStore customerStore)
    {
        SubmitCommand = submitCommand;
        CancelCommand = cancelCommand;

        _breakdownSolverStore = breakdownSolverStore;
        _departmentStore = departmentStore;
        _sectorStore = sectorStore;
        _employeeStore = employeeStore;
        _customerStore = customerStore;

        _breakdownSolverListingViewModel = new BreakdownSolverListingViewModel(breakdownSolverStore);
        _departmentListingViewModel = new DepartmentListingViewModel(departmentStore);
        _sectorListingViewModel = new SectorListingViewModel(sectorStore);
        _breakdownListingViewModel = new EmployeeListingViewModel(employeeStore);
        _customerListingViewModel = new CustomerListingViewModel(customerStore);

    }


    #region COMMANDS
    public ICommand SubmitCommand { get; }
    public ICommand CancelCommand { get; }

    public ICommand LoadComboBoxItemsCommand { get; }

    public static RelayCommand UploadPhotoCommand { get; set; }

    #endregion

    #region PROPERTIES


    private bool _isElectrical;

    public bool IsElectrical
    {
        get { return _isElectrical; }
        set
        {
            _isElectrical = value;
            OnPropertyChanged(nameof(IsElectrical));
        }
    }

    private bool _isMechanical;

    public bool IsMechanical
    {
        get { return _isMechanical; }
        set
        {
            _isMechanical = value;
            OnPropertyChanged(nameof(IsMechanical));
        }
    }


    private string _department;

    public string Department
    {
        get { return _department; }
        set
        {
            _department = value;
            OnPropertyChanged(nameof(Department));
        }
    }


    private string _sector;

    public string Sector
    {
        get { return _sector; }
        set
        {
            _sector = value;
            OnPropertyChanged(nameof(Sector));
        }
    }



    private string _cause;

    public string Cause
    {
        get { return _cause; }
        set
        {
            _cause = value;
            OnPropertyChanged(nameof(Cause));
        }
    }


    private string _errorMessage;

    public string ErrorMessage
    {
        get { return _errorMessage; }
        set
        {
            _errorMessage = value;
            OnPropertyChanged(nameof(ErrorMessage));
            OnPropertyChanged(nameof(HasErrorMessage));
        }
    }


    private string _errorMessageTryLater;

    public string ErrorMessageTryLater
    {
        get { return _errorMessageTryLater; }
        set
        {
            _errorMessageTryLater = value;
            OnPropertyChanged(nameof(ErrorMessageTryLater));
            OnPropertyChanged(nameof(HasErrorMessage));
        }
    }

    private bool _isSubmitting;

    public bool IsSubmitting
    {
        get { return _isSubmitting; }
        set
        {
            _isSubmitting = value;
            OnPropertyChanged(nameof(IsSubmitting));
        }
    }


    public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

    public bool CanSubmit => SelectedCountryItem != null &&
                             SelectedDepartmentItem != null &&
                             SelectedSectorItem != null &&
                             SelectedEmployeeItem != null;

    #endregion

    #region SELECTED ITEMS


    private SectorListingItemViewModel _selectedSectorItem;

    public SectorListingItemViewModel SelectedSectorItem
    {
        get { return _selectedSectorItem; }
        set
        {
            _selectedSectorItem = value;
            OnPropertyChanged(nameof(SelectedSectorItem));
            OnPropertyChanged(nameof(CanSubmit));
        }
    }


    private DepartmentListingItemViewModel _selectedDepartmentItem;
    public DepartmentListingItemViewModel SelectedDepartmentItem
    {
        get { return _selectedDepartmentItem; }
        set
        {
            _selectedDepartmentItem = value;
            OnPropertyChanged(nameof(SelectedDepartmentItem));
            OnPropertyChanged(nameof(CanSubmit));

        }
    }


    private EmployeeListingItemViewModel _selectedEmployeeItem;

    public EmployeeListingItemViewModel SelectedEmployeeItem
    {
        get { return _selectedEmployeeItem; }
        set
        {
            _selectedEmployeeItem = value;
            OnPropertyChanged(nameof(SelectedEmployeeItem));
            OnPropertyChanged(nameof(CanSubmit));

        }
    }

    private CustomerListingItemViewModel _selectedCompanyItem;

    public CustomerListingItemViewModel SelectedCompanyItem
    {
        get { return _selectedCompanyItem; }
        set
        {
            _selectedCompanyItem = value;
            OnPropertyChanged(nameof(SelectedCompanyItem));

        }
    }

    private CustomerListingItemViewModel _selectedCountryItem;

    public CustomerListingItemViewModel SelectedCountryItem
    {
        get { return _selectedCountryItem; }
        set
        {
            _selectedCountryItem = value;
            SelectedCountry = _selectedCountryItem.Country;
            if (IsSelectedCountry == false)
                IsSelectedCountry = true;
            OnPropertyChanged(nameof(SelectedCountryItem));
            OnPropertyChanged(nameof(CanSubmit));


        }
    }

    private bool _isSelectedCountry = false;

    public bool IsSelectedCountry
    {
        get { return _isSelectedCountry; }
        set
        {
            _isSelectedCountry = value;
            OnPropertyChanged(nameof(IsSelectedCountry));
        }
    }


    #endregion

    #region SELECTED VALUES
    private int _selectedSectorValue;

    public int SelectedSectorValue
    {
        get { return _selectedSectorValue; }
        set { _selectedSectorValue = value; }
    }

    private int _selectedDepartmentValue;

    public int SelectedDepartmentValue
    {
        get { return _selectedDepartmentValue; }
        set { _selectedDepartmentValue = value; }
    }


    private int _selectedEmployeeValue;

    public int SelectedEmployeeValue
    {
        get { return _selectedEmployeeValue; }
        set { _selectedEmployeeValue = value; }
    }

    private int _selectedCompanyValue;

    public int SelectedCompanyValue
    {
        get { return _selectedCompanyValue; }
        set { _selectedCompanyValue = value; }
    }

    private int _selectedCountryValue;

    public int SelectedCountryValue
    {
        get { return _selectedCountryValue; }
        set { _selectedCountryValue = value; }
    }



    #endregion



    private string _selectedCountry;
    public string SelectedCountry
    {
        get { return _selectedCountry; }
        set
        {
            _selectedCountry = value;
            OnPropertyChanged(nameof(CompanyNameListing));
        }
    }
}
