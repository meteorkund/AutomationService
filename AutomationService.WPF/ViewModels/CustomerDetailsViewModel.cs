using AutomationService.Domain.Models;
using AutomationService.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.ViewModels
{
    public class CustomerDetailsViewModel : ViewModelBase
    {
        readonly SelectedCustomerStore _selectedCustomerStore;
        private Customer SelectedCustomer => _selectedCustomerStore.SelectedCustomer;


        public bool HasSelectedCustomer => SelectedCustomer != null;
        public string CompanyName => SelectedCustomer?.CompanyName ?? "Lütfen bir şirket seçin.";
        public string BreakdownStatusDisplay => (SelectedCustomer?.Breakdown.Status ?? false) ? "AKTİF" : "DEAKTİF";
        public string IsElectricalDisplay => (SelectedCustomer?.Breakdown.IsElectrical ?? false) ? "EVET" : "HAYIR";
        public string IsMechanicalDisplay => (SelectedCustomer?.Breakdown.IsMechanical ?? false) ? "EVET" : "HAYIR";

        public CustomerDetailsViewModel(SelectedCustomerStore selectedCustomerStore)
        {
            _selectedCustomerStore = selectedCustomerStore;

            _selectedCustomerStore.SelectedCustomerChanged += SelectedCustomerStore_SelectedCustomerChanged;

        }

        protected override void Dispose()
        {
            _selectedCustomerStore.SelectedCustomerChanged -= SelectedCustomerStore_SelectedCustomerChanged;
            base.Dispose();
        }

        private void SelectedCustomerStore_SelectedCustomerChanged()
        {
            OnPropertyChanged(nameof(HasSelectedCustomer));
            OnPropertyChanged(nameof(CompanyName));
            OnPropertyChanged(nameof(BreakdownStatusDisplay));
            OnPropertyChanged(nameof(IsElectricalDisplay));
            OnPropertyChanged(nameof(IsMechanicalDisplay));
        }
    }
}
