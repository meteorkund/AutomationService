using AutomationService.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        readonly ModalNavigationStore _modalNavigationStore;
        public ViewModelBase CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;
        public BreakdownsViewModel BreakdownsViewModel { get; }

        public bool IsModalOpen => _modalNavigationStore.IsOpen;

        public MainViewModel(ModalNavigationStore modalNavigationStore, BreakdownsViewModel customersViewModel)
        {
            _modalNavigationStore = modalNavigationStore;
            BreakdownsViewModel = customersViewModel;

            _modalNavigationStore.CurrentViewModelChanged += _modalNavigationStore_CurrentViewModelChanged;

        }

        private void _modalNavigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsModalOpen));
        }

        protected override void Dispose()
        {
            _modalNavigationStore.CurrentViewModelChanged -= _modalNavigationStore_CurrentViewModelChanged;

            base.Dispose();
        }


    }
}
