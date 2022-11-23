using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.ComboBoxItemsViewModels.BreakdownSolverViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomationService.WPF.ViewModels.BreakdownViewModels
{
    public class SolveBreakdownFormViewModel : ViewModelBase
    {
        readonly BreakdownSolverStore _breakdownSolverStore;
        readonly BreakdownSolverListingViewModel _breakdownSolverListingViewModel;

        public IEnumerable<BreakdownSolverListingItemViewModel> BreakdownSolverListingItemViewModels => _breakdownSolverListingViewModel.BreakdownSolverListingItemViewModels;

        public SolveBreakdownFormViewModel(ICommand submitCommand, ICommand cancelCommand, BreakdownSolverStore breakdownSolverStore)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;

            _breakdownSolverListingViewModel = new BreakdownSolverListingViewModel(breakdownSolverStore);

        }

        #region COMMANDS

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        #endregion

        #region SELECTED ITEMS

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
        #endregion

        #region PROPERTIES


        private int _selectedBreakdownSolverValue;

        public int SelectedBreakdownSolverValue
        {
            get { return _selectedBreakdownSolverValue; }
            set { _selectedBreakdownSolverValue = value; }
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

        #endregion

    }
}
