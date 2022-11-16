using AutomationService.Domain.Models;
using AutomationService.Domain.Models.Common;
using AutomationService.WPF.Commands;
using AutomationService.WPF.Stores;
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
        readonly BreakdownStore _BreakdownStore;
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
        public BreakdownListingViewModel(BreakdownStore breakdownStore, SelectedBreakdownStore selectedBreakdownStore, ModalNavigationStore modalNavigationStore)
        {
            _selectedBreakdownStore = selectedBreakdownStore;
            _modalNavigationStore = modalNavigationStore;
            _BreakdownStore = breakdownStore;
            _breakdownListingItemViewModels = new ObservableCollection<BreakdownListingItemViewModel>();

            LoadBreakdownsCommand = new LoadBreakdownsCommand(this, breakdownStore);

            _BreakdownStore.BreakdownsLoaded += BreakdownStore_CustomersLoaded;
            _BreakdownStore.BreakdownAdded += BreakdownStore_CustomerAdded;
            _BreakdownStore.BreakdownUpdated += BreakdownStore_CustomerUpdated;
            _BreakdownStore.BreakdownDeleted += BreakdownStore_CustomerDeleted;
        }

        public static BreakdownListingViewModel LoadViewModel(BreakdownStore breakdownStore, SelectedBreakdownStore selectedBreakdownStore, ModalNavigationStore modalNavigationStore)
        {
            BreakdownListingViewModel viewModel = new BreakdownListingViewModel(breakdownStore, selectedBreakdownStore, modalNavigationStore);

            viewModel.LoadBreakdownsCommand.Execute(null);

            return viewModel;
        }


        protected override void Dispose()
        {
            _BreakdownStore.BreakdownsLoaded -= BreakdownStore_CustomersLoaded;
            _BreakdownStore.BreakdownAdded -= BreakdownStore_CustomerAdded;
            _BreakdownStore.BreakdownUpdated -= BreakdownStore_CustomerUpdated;
            _BreakdownStore.BreakdownDeleted -= BreakdownStore_CustomerDeleted;

            base.Dispose();
        }


        private void BreakdownStore_CustomersLoaded()
        {
            _breakdownListingItemViewModels.Clear();
            foreach (Breakdown employee in _BreakdownStore.Breakdowns)
            {
                AddCustomer(employee);
            }
        }
        private void BreakdownStore_CustomerAdded(Breakdown employee)
        {
            AddCustomer(employee);
        }

        private void BreakdownStore_CustomerUpdated(Breakdown employee)
        {
            BreakdownListingItemViewModel employeeViewModel = _breakdownListingItemViewModels.FirstOrDefault(e => e.Breakdown.Id == employee.Id);

            if (employeeViewModel != null)
                employeeViewModel.Update(employee);
        }


        private void BreakdownStore_CustomerDeleted(int id)
        {
            BreakdownListingItemViewModel itemViewModel = _breakdownListingItemViewModels.FirstOrDefault(e => e.Breakdown?.Id == id);

            if (itemViewModel != null)
                _breakdownListingItemViewModels.Remove(itemViewModel);

        }



        private void AddCustomer(Breakdown employee)
        {
            BreakdownListingItemViewModel itemViewModel = new BreakdownListingItemViewModel(employee, _BreakdownStore, _modalNavigationStore);
            _breakdownListingItemViewModels.Add(itemViewModel);
        }
    }
}
