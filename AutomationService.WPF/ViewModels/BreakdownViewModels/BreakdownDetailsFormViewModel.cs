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

    public IEnumerable<CustomerListingItemViewModel> CompanyNameListing => _customerListingViewModel._customerListingItemViewModels.Where(x => x.Country == SelectedCountry).ToList();




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

    private string _service;

    public string Service
    {
        get { return _service; }
        set
        {
            _service = value;
            OnPropertyChanged(nameof(Service));
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
    #endregion

    public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

    public ICommand SubmitCommand { get; }
    public ICommand CancelCommand { get; }

    public ICommand LoadComboBoxItemsCommand { get; }

    public static RelayCommand UploadPhotoCommand { get; set; }

    public BreakdownDetailsFormViewModel(ICommand submitCommand, ICommand cancelCommand, BreakdownSolverStore breakdownSolverStore, DepartmentStore departmentStore, SectorStore sectorStore, EmployeeStore employeeStore, CustomerStore customerStore)
    {
        SubmitCommand = submitCommand;
        CancelCommand = cancelCommand;

        _breakdownSolverStore = breakdownSolverStore;
        _departmentStore = departmentStore;
        _sectorStore = sectorStore;
        _customerStore = customerStore;

        _breakdownSolverListingViewModel = new BreakdownSolverListingViewModel(this, breakdownSolverStore);
        _departmentListingViewModel = new DepartmentListingViewModel(this, departmentStore);
        _sectorListingViewModel = new SectorListingViewModel(this, sectorStore);
        _breakdownListingViewModel = new EmployeeListingViewModel(this, employeeStore);
        _customerListingViewModel = new CustomerListingViewModel(this, customerStore);

    }





    private SectorListingItemViewModel _selectedSectorItem;

    public SectorListingItemViewModel SelectedSectorItem
    {
        get { return _selectedSectorItem; }
        set
        {
            _selectedSectorItem = value;
            OnPropertyChanged(nameof(SelectedSectorItem));
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
        }
    }

    private BreakdownSolverListingItemViewModel _selectedBreakdownSolverItem;
    public BreakdownSolverListingItemViewModel SelectedBreakdownSolverItem
    {
        get { return _selectedBreakdownSolverItem; }
        set
        {
            _selectedBreakdownSolverItem = value;
            OnPropertyChanged(nameof(SelectedBreakdownSolverItem));
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
            OnPropertyChanged(nameof(SelectedCountryItem));

        }
    }

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

    private int _selectedBreakdownSolverValue;

    public int SelectedBreakdownSolverValue
    {
        get { return _selectedBreakdownSolverValue; }
        set { _selectedBreakdownSolverValue = value; }
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





    private int _selectedIndexCommon;
    public int SelectedIndexCommon
    {
        get { return _selectedIndexCommon; }
        set { _selectedIndexCommon = value; }
    }

}
