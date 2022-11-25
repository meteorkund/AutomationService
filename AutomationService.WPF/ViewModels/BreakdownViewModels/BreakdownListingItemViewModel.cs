using AutomationService.Domain.Models;
using AutomationService.WPF.Commands;
using AutomationService.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomationService.WPF.ViewModels.BreakdownViewModels;

public class BreakdownListingItemViewModel : ViewModelBase
{
    public Breakdown Breakdown { get; private set; }
    public Guid BreakdownId => Breakdown.Id;
    public bool Status => Breakdown.Status;
    public string CompanyName => Breakdown.Customer.CompanyName;
    public string Country => Breakdown.Customer.Country;
    public string Department => Breakdown.Department.DepartmentName;
    public string Sector => Breakdown.Sector.SectorName;
    public string CreatorName => Breakdown.Employee.NameSurname;
    public string CreatedDate => Breakdown.CreatedDate.ToString();

    

    public ICommand EditCommand { get; }
    public ICommand DeleteCommand { get; }

    private bool _isDeleting;

    public bool IsDeleting
    {
        get { return _isDeleting; }
        set
        {
            _isDeleting = value;

            OnPropertyChanged(nameof(IsDeleting));
        }
    }

    public BreakdownListingItemViewModel(Breakdown breakdown, BreakdownStore breakdownStore, ModalNavigationStore modalNavigationStore, BreakdownSolverStore breakdownSolverStore, DepartmentStore departmentStore, SectorStore sectorStore, EmployeeStore employeeStore, CustomerStore customerStore)
    {
        Breakdown = breakdown;
        EditCommand = new OpenEditBreakdownCommand(this, breakdownStore, modalNavigationStore, breakdownSolverStore, departmentStore, sectorStore, employeeStore, customerStore);
        DeleteCommand = new DeleteBreadownCommand(this, breakdownStore);
    }

    public void Update(Breakdown breakdown)
    {
        Breakdown = breakdown;
        OnPropertyChanged(nameof(BreakdownId));
        OnPropertyChanged(nameof(Status));
        OnPropertyChanged(nameof(CompanyName));
        OnPropertyChanged(nameof(Country));
        OnPropertyChanged(nameof(Department));
        OnPropertyChanged(nameof(Sector));

    }
}
