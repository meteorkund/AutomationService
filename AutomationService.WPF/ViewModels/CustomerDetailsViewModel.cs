using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.ViewModels
{
    public class CustomerDetailsViewModel :ViewModelBase
    {
        public string CompanyName { get; }
        public string BreakdownStatusDisplay { get; }
        public string BreakdownTypeDisplay { get; }

        public CustomerDetailsViewModel()
        {
            CompanyName = "Demir İNŞ";
            BreakdownStatusDisplay = "AKTİF";
            BreakdownTypeDisplay = "ELEKTRİK";
        }
    }
}
