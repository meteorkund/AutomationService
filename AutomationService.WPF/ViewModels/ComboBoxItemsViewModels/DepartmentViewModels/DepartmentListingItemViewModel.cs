using AutomationService.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.ViewModels.ComboBoxItemsViewModels.DepartmentViewModels
{
    public class DepartmentListingItemViewModel : ViewModelBase
    {
        public Department Department { get; private set; }

        public int DepartmentId => Department.Id;
        public string DepartmentName => Department.DepartmentName;

        public DepartmentListingItemViewModel(Department department)
        {
            Department = department;
        }
    }
}
