using AutomationService.Domain.Models;
using AutomationService.EF;
using AutomationService.WPF.Commands.BreakdownFileCommands;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.BreakdownFileViewModels;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AutomationService.WPF.ViewModels.BreakdownViewModels
{
    public class BreakdownDetailsViewModel : ViewModelBase
    {
        readonly SelectedBreakdownStore _selectedBreakdownStore;
        readonly SelectedBreakdownFileStore _selectedBreakdownFileStore;
        readonly AutomationServiceDBContextFactory _contextFactory;
        private Breakdown SelectedBreakdown => _selectedBreakdownStore.SelectedBreakdown;

        readonly BreakdownFileListingViewModel _breakdownFileListingViewModel;

        public bool HasSelectedBreakdown => SelectedBreakdown != null;

        public bool BreakdownStatusDisplay => (bool)SelectedBreakdown?.Status;
        public string CompanyNameDisplay => SelectedBreakdown?.Customer.CompanyName ?? "Lütfen bir şirket seçin.";
        public string CountryDisplay => SelectedBreakdown?.Customer.Country;

        public string DepartmentDisplay => SelectedBreakdown?.Department.DepartmentName;
        public string SectorDisplay => SelectedBreakdown?.Sector.SectorName;

        public string IsElectricalDisplay => SelectedBreakdown?.IsElectrical ?? false ? "EVET" : "HAYIR";
        public string IsMechanicalDisplay => SelectedBreakdown?.IsMechanical ?? false ? "EVET" : "HAYIR";

        public string CauseDisplay => SelectedBreakdown?.Cause;
        public string ServiceDisplay => SelectedBreakdown?.Service;

        public string CreatorNameDisplay => SelectedBreakdown?.Employee?.NameSurname;
        public string BreakdownSolverDisplay => SelectedBreakdown?.BreakdownSolver?.NameSurname;

        public string CreatedDateDisplay => SelectedBreakdown?.CreatedDate.ToString();
        public string UpdatedDateDisplay => SelectedBreakdown?.UpdatedDate.ToString();


        public BreakdownFileListingViewModel BreakdownFileListingViewModel { get; set; }

        public ICommand AddFileCommand { get; }

        public BreakdownDetailsViewModel(SelectedBreakdownStore selectedBreakdownStore,
                                         BreakdownFileStore breakdownFileStore,
                                         SelectedBreakdownFileStore selectedBreakdownFileStore,
                                         AutomationServiceDBContextFactory contextFactory)
        {
            _selectedBreakdownStore = selectedBreakdownStore;
            _selectedBreakdownFileStore = selectedBreakdownFileStore;

            BreakdownFileListingViewModel = BreakdownFileListingViewModel.LoadViewModel(breakdownFileStore, selectedBreakdownFileStore, selectedBreakdownStore);

            AddFileCommand = new AddBreakdownFilesCommand(breakdownFileStore, contextFactory, selectedBreakdownStore);

            _breakdownFileListingViewModel = new BreakdownFileListingViewModel(breakdownFileStore, selectedBreakdownFileStore, selectedBreakdownStore);

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
            OnPropertyChanged(nameof(CreatorNameDisplay));
            OnPropertyChanged(nameof(BreakdownSolverDisplay));

            OnPropertyChanged(nameof(CreatedDateDisplay));
            OnPropertyChanged(nameof(UpdatedDateDisplay));
        }
    }
}
