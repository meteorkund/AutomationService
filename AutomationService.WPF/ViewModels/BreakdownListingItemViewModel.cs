using AutomationService.Domain.Models;
using AutomationService.WPF.Commands;
using AutomationService.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomationService.WPF.ViewModels;

public class BreakdownListingItemViewModel : ViewModelBase
{
    public Breakdown Breakdown { get; private set; }
    public int BreakdownId => Breakdown.Id;
    public bool Status => Breakdown.Status;
    public string CompanyName => Breakdown.Customer.CompanyName;
    public string Country => Breakdown.Customer.Country;
    public string Department => Breakdown.Department;
    public string Sector => Breakdown.Sector;


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

    public BreakdownListingItemViewModel(Breakdown breakdown, BreakdownStore breakdownStore, ModalNavigationStore modalNavigationStore)
    {
        Breakdown = breakdown;
        EditCommand = new OpenEditBreakdownCommand(this, breakdownStore, modalNavigationStore);
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
