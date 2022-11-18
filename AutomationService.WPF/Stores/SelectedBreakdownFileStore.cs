using AutomationService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.Stores
{
    public class SelectedBreakdownFileStore
    {
        readonly BreakdownFileStore _breakdownFileStore;
        private BreakdownFile _selectedBreakdownFile;

        public SelectedBreakdownFileStore(BreakdownFileStore breakdownFileStore)
        {
            _breakdownFileStore = breakdownFileStore;
        }


        public BreakdownFile SelectedBreakdownFile
        {
            get
            {
                return _selectedBreakdownFile;
            }
            set
            {
                _selectedBreakdownFile = value;
                SelectedBreakdownFileChanged?.Invoke();
            }
        }

        public event Action SelectedBreakdownFileChanged;

    }
}
