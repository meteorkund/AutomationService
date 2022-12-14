using AutomationService.Domain.Models;
using AutomationService.Domain.Models.Common;
using AutomationService.EF;
using AutomationService.WPF.Commands;
using AutomationService.WPF.Commands.ComboBoxItemsCommand;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.BreakdownFileViewModels;
using AutomationService.WPF.ViewModels.ComboBoxItemsViewModels.EmployeeViewModels;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace AutomationService.WPF.ViewModels.BreakdownViewModels
{
    public class BreakdownListingViewModel : ViewModelBase
    {
        readonly SelectedBreakdownStore _selectedBreakdownStore;
        readonly ObservableCollection<BreakdownListingItemViewModel> _breakdownListingItemViewModels;

        readonly AutomationServiceDBContextFactory _contextFactory;

        readonly BreakdownStore _breakdownStore;
        readonly BreakdownSolverStore _breakdownSolverStore;
        readonly DepartmentStore _departmentStore;
        readonly SectorStore _sectorStore;
        readonly EmployeeStore _employeeStore;
        readonly CustomerStore _customerStore;

        readonly ModalNavigationStore _modalNavigationStore;

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



        private ICollectionView _employeeCollection;
        public ICollectionView EmployeeCollection
        {
            get { return _employeeCollection; }
            set { _employeeCollection = value; }
        }


        public TopMenuViewModel TopMenuViewModel { get; }

        public ICommand LoadBreakdownsCommand { get; }
        public ICommand LoadComboBoxItemsCommand { get; }
        public BreakdownListingViewModel(BreakdownStore breakdownStore, SelectedBreakdownStore selectedBreakdownStore, ModalNavigationStore modalNavigationStore, BreakdownSolverStore breakdownSolverStore, DepartmentStore departmentStore, SectorStore sectorStore, EmployeeStore employeeStore, AutomationServiceDBContextFactory contextFactory, CustomerStore customerStore)
        {
            _contextFactory = contextFactory;

            _selectedBreakdownStore = selectedBreakdownStore;
            _modalNavigationStore = modalNavigationStore;

            _breakdownStore = breakdownStore;
            _breakdownSolverStore = breakdownSolverStore;
            _departmentStore = departmentStore;
            _sectorStore = sectorStore;
            _employeeStore = employeeStore;
            _customerStore= customerStore;

            _breakdownListingItemViewModels = new ObservableCollection<BreakdownListingItemViewModel>();



            EmployeeCollection = CollectionViewSource.GetDefaultView(_breakdownListingItemViewModels);


            LoadBreakdownsCommand = new LoadBreakdownsCommand(this, breakdownStore);
            LoadComboBoxItemsCommand = new LoadComboBoxItemsCommand(breakdownSolverStore, departmentStore, sectorStore, employeeStore, customerStore);

            _breakdownStore.BreakdownsLoaded += BreakdownStore_BreakdownsLoaded;
            _breakdownStore.BreakdownAdded += BreakdownStore_BreakdownAdded;
            _breakdownStore.BreakdownUpdated += BreakdownStore_BreakdownUpdated;
            _breakdownStore.BreakdownDeleted += BreakdownStore_BreakdownDeleted;

        }


        public static BreakdownListingViewModel LoadViewModel(BreakdownStore breakdownStore, SelectedBreakdownStore selectedBreakdownStore, ModalNavigationStore modalNavigationStore, BreakdownSolverStore breakdownSolverStore, DepartmentStore departmentStore, SectorStore sectorStore, EmployeeStore employeeStore, AutomationServiceDBContextFactory contextFactory, CustomerStore customerStore)
        {
            BreakdownListingViewModel viewModel = new BreakdownListingViewModel(breakdownStore, selectedBreakdownStore, modalNavigationStore, breakdownSolverStore, departmentStore, sectorStore, employeeStore,contextFactory, customerStore);

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




        private bool FilterByStatus(object emp)
        {
            var empDetail = emp as BreakdownListingItemViewModel;

            return empDetail.Status.Equals(true);

        }

        private void BreakdownStore_BreakdownsLoaded()
        {
            _breakdownListingItemViewModels.Clear();
            foreach (Breakdown breakdown in _breakdownStore.Breakdowns)
            {
                AddBreakdown(breakdown);
            }

            EmployeeCollection.Filter = FilterByStatus;
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


        private void BreakdownStore_BreakdownDeleted(Guid id)
        {
            BreakdownListingItemViewModel itemViewModel = _breakdownListingItemViewModels.FirstOrDefault(e => e.Breakdown?.Id == id);

            if (itemViewModel != null)
                _breakdownListingItemViewModels.Remove(itemViewModel);

        }



        private void AddBreakdown(Breakdown breakdown)
        {
            BreakdownListingItemViewModel itemViewModel = new BreakdownListingItemViewModel(breakdown, _breakdownStore, _modalNavigationStore, _breakdownSolverStore, _departmentStore, _sectorStore, _employeeStore, _customerStore);
            _breakdownListingItemViewModels.Add(itemViewModel);
        }
    }
}
