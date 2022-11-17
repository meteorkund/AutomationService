using AutomationService.Domain.Models;
using AutomationService.EF;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.BreakdownFileViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutomationService.WPF.ViewModels.BreakdownViewModels
{
    public class BreakdownDetailsViewModel : ViewModelBase
    {
        readonly SelectedBreakdownStore _selectedBreakdownStore;
        readonly AutomationServiceDBContextFactory _contextFactory;
        private Breakdown SelectedBreakdown => _selectedBreakdownStore.SelectedBreakdown;

        readonly BreakdownFileListingViewModel _breakdownFileListingViewModel;


        public bool HasSelectedBreakdown => SelectedBreakdown != null;

        public bool BreakdownStatusDisplay => SelectedBreakdown.Status;
        public string CompanyNameDisplay => SelectedBreakdown?.Customer.CompanyName ?? "Lütfen bir şirket seçin.";
        public string CountryDisplay => SelectedBreakdown?.Customer.Country;

        public string DepartmentDisplay => SelectedBreakdown?.Department;
        public string SectorDisplay => SelectedBreakdown?.Sector;

        public string IsElectricalDisplay => SelectedBreakdown?.IsElectrical ?? false ? "EVET" : "HAYIR";
        public string IsMechanicalDisplay => SelectedBreakdown?.IsMechanical ?? false ? "EVET" : "HAYIR";

        public string CauseDisplay => SelectedBreakdown?.Cause;
        public string ServiceDisplay => SelectedBreakdown?.Service;

        public IEnumerable<BreakdownFileListingItemViewModel> BreakdownFileListingItemViewModels => _breakdownFileListingViewModel.BreakdownFileListingItemViewModels;

        public BreakdownFileListingViewModel BreakdownFileListingViewModel { get; set; }

        public BreakdownDetailsViewModel(SelectedBreakdownStore selectedBreakdownStore, BreakdownFileStore breakdownFileStore)
        {
            _selectedBreakdownStore = selectedBreakdownStore;

            BreakdownFileListingViewModel = BreakdownFileListingViewModel.LoadViewModel(breakdownFileStore);
            _breakdownFileListingViewModel = new BreakdownFileListingViewModel(breakdownFileStore);

            _selectedBreakdownStore.SelectedBreakdownChanged += SelectedBreakdownStore_SelectedCustomerChanged;

        }

        protected override void Dispose()
        {
            _selectedBreakdownStore.SelectedBreakdownChanged -= SelectedBreakdownStore_SelectedCustomerChanged;
            base.Dispose();
        }

        private void SelectedBreakdownStore_SelectedCustomerChanged()
        {
            OnPropertyChanged(nameof(HasSelectedBreakdown));
            OnPropertyChanged(nameof(BreakdownStatusDisplay));
            OnPropertyChanged(nameof(CompanyNameDisplay));
            OnPropertyChanged(nameof(CountryDisplay));
            OnPropertyChanged(nameof(DepartmentDisplay));
            OnPropertyChanged(nameof(SectorDisplay));
            OnPropertyChanged(nameof(IsElectricalDisplay));
            OnPropertyChanged(nameof(IsMechanicalDisplay));
            OnPropertyChanged(nameof(CauseDisplay));
            OnPropertyChanged(nameof(ServiceDisplay));
        }
    }
}
