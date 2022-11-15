using AutomationService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.Stores
{
    public class SelectedBreakdownStore
    {
        readonly BreakdownStore _breakdownStore;
        private Breakdown _selectedBreakdown;

        public SelectedBreakdownStore(BreakdownStore breakdownStore)
        {
            _breakdownStore = breakdownStore;

            _breakdownStore.BreakdownUpdated += EmployeeStore_EmployeeUpdated;
        }

        private void EmployeeStore_EmployeeUpdated(Breakdown breakdown)
        {
            if (breakdown.Id == SelectedBreakdown?.Id)
                SelectedBreakdown = breakdown;
        }

        public Breakdown SelectedBreakdown
        {
            get { return _selectedBreakdown; }
            set
            {
                _selectedBreakdown = value;
                SelectedBreakdownChanged?.Invoke();
            }
        }
        public event Action SelectedBreakdownChanged;

    }
}
