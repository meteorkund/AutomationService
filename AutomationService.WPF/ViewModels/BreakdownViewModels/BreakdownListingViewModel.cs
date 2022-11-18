using AutomationService.Domain.Models;
using AutomationService.Domain.Models.Common;
using AutomationService.WPF.Commands;
using AutomationService.WPF.Commands.ComboBoxItemsCommand;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.BreakdownFileViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomationService.WPF.ViewModels.BreakdownViewModels
{
    public class BreakdownListingViewModel : ViewModelBase
    {
        readonly SelectedBreakdownStore _selectedBreakdownStore;
        readonly ObservableCollection<BreakdownListingItemViewModel> _breakdownListingItemViewModels;

        readonly BreakdownStore _breakdownStore;
        readonly BreakdownSolverStore _breakdownSolverStore;
        readonly DepartmentStore _departmentStore;
        readonly SectorStore _sectorStore;
        readonly EmployeeStore _employeeStore;

        readonly ModalNavigationStore _modalNavigationStore;

        public IEnumerable<BreakdownListingItemViewModel> BreakdownListingItemViewModels => _breakdownListingItemViewModels;

        public BreakdownListingItemViewModel SelectedBreakdownListingItemViewModel
        {
            get
            {
                return _breakdownListingItemViewModels
                    .FirstOrDefault(e => e.Breakdown?.Id == _selectedBreakdownStore.SelectedBreakdown?.Id);
            }
            set
            {

                _selectedBreakdownStore.SelectedBreakdown = value?.Breakdown;
            }
        }

        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
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
        public bool HasErrorMessage => !string.IsNullOrWhiteSpace(ErrorMessage);


        public ICommand LoadBreakdownsCommand { get; }
        public ICommand LoadComboBoxItemsCommand { get; }
        public BreakdownListingViewModel(BreakdownStore breakdownStore, SelectedBreakdownStore selectedBreakdownStore, ModalNavigationStore modalNavigationStore, BreakdownSolverStore breakdownSolverStore, DepartmentStore departmentStore, SectorStore sectorStore, EmployeeStore employeeStore)
        {
            _selectedBreakdownStore = selectedBreakdownStore;
            _modalNavigationStore = modalNavigationStore;

            _breakdownStore = breakdownStore;
            _breakdownSolverStore = breakdownSolverStore;
            _departmentStore = departmentStore;
            _sectorStore = sectorStore;
            _employeeStore = employeeStore;

            _breakdownListingItemViewModels = new ObservableCollection<BreakdownListingItemViewModel>();

            LoadBreakdownsCommand = new LoadBreakdownsCommand(this, breakdownStore);
            LoadComboBoxItemsCommand = new LoadComboBoxItemsCommand(breakdownSolverStore, departmentStore, sectorStore, employeeStore);

            _breakdownStore.BreakdownsLoaded += BreakdownStore_BreakdownsLoaded;
            _breakdownStore.BreakdownAdded += BreakdownStore_BreakdownAdded;
            _breakdownStore.BreakdownUpdated += BreakdownStore_BreakdownUpdated;
            _breakdownStore.BreakdownDeleted += BreakdownStore_BreakdownDeleted;

        }


        public static BreakdownListingViewModel LoadViewModel(BreakdownStore breakdownStore, SelectedBreakdownStore selectedBreakdownStore, ModalNavigationStore modalNavigationStore, BreakdownSolverStore breakdownSolverStore, DepartmentStore departmentStore, SectorStore sectorStore, EmployeeStore employeeStore)
        {
            BreakdownListingViewModel viewModel = new BreakdownListingViewModel(breakdownStore, selectedBreakdownStore, modalNavigationStore, breakdownSolverStore, departmentStore, sectorStore, employeeStore);

            viewModel.LoadBreakdownsCommand.Execute(null);
            viewModel.LoadComboBoxItemsCommand.Execute(null);

            return viewModel;
        }


        protected override void Dispose()
        {
            _breakdownStore.BreakdownsLoaded -= BreakdownStore_BreakdownsLoaded;
            _breakdownStore.BreakdownAdded -= BreakdownStore_BreakdownAdded;
            _breakdownStore.BreakdownUpdated -= BreakdownStore_BreakdownUpdated;
            _breakdownStore.BreakdownDeleted -= BreakdownStore_BreakdownDeleted;

            base.Dispose();
        }





        private void BreakdownStore_BreakdownsLoaded()
        {
            _breakdownListingItemViewModels.Clear();
            foreach (Breakdown breakdown in _breakdownStore.Breakdowns)
            {
                AddBreakdown(breakdown);
            }
        }
        private void BreakdownStore_BreakdownAdded(Breakdown breakdown)
        {
            AddBreakdown(breakdown);
        }

        private void BreakdownStore_BreakdownUpdated(Breakdown breakdown)
        {
            BreakdownListingItemViewModel breakdownViewModel = _breakdownListingItemViewModels.FirstOrDefault(e => e.Breakdown.Id == breakdown.Id);

            if (breakdownViewModel != null)
                breakdownViewModel.Update(breakdown);
        }


        private void BreakdownStore_BreakdownDeleted(int id)
        {
            BreakdownListingItemViewModel itemViewModel = _breakdownListingItemViewModels.FirstOrDefault(e => e.Breakdown?.Id == id);

            if (itemViewModel != null)
                _breakdownListingItemViewModels.Remove(itemViewModel);

        }



        private void AddBreakdown(Breakdown breakdown)
        {
            BreakdownListingItemViewModel itemViewModel = new BreakdownListingItemViewModel(breakdown, _breakdownStore, _modalNavigationStore, _breakdownSolverStore, _departmentStore, _sectorStore, _employeeStore);
            _breakdownListingItemViewModels.Add(itemViewModel);
        }
    }
}
