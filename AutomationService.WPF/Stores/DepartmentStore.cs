using AutomationService.Domain.Models.Common;
using AutomationService.Domain.Queries;
using AutomationService.WPF.ViewModels;
using AutomationService.WPF.ViewModels.ComboBoxItemsViewModels.DepartmentViewModels;
using AutomationService.WPF.ViewModels.ComboBoxItemsViewModels.SectorViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.Stores
{
    public class DepartmentStore : ViewModelBase
    {
        readonly IGetAllDepartmentsQuery _getAllDepartments;

        readonly List<Department> _departments;
        public IEnumerable<Department> Departments => _departments;

        public ObservableCollection<DepartmentListingItemViewModel> _departmentListingItemViewModels;


        public event Action DepartmentsLoaded;


        public DepartmentStore(IGetAllDepartmentsQuery getAllDepartments)
        {
            _getAllDepartments = getAllDepartments;
            _departments = new List<Department>();

            _departmentListingItemViewModels = new ObservableCollection<DepartmentListingItemViewModel>();

            DepartmentsLoaded += DepartmentStore_DepartmentStoreLoaded;
        }



        public async Task LoadDepartments()
        {
            IEnumerable<Department> departments = await _getAllDepartments.GetAllDepartments();

            _departments.Clear();

            IEnumerable<Department> sortedDepartments = departments.OrderBy(d => d.DepartmentName).ToList();

            _departments.AddRange(sortedDepartments);

            DepartmentsLoaded?.Invoke();
        }

        private void AddDepartment(Department department)
        {
            DepartmentListingItemViewModel itemViewModel = new DepartmentListingItemViewModel(department);

            _departmentListingItemViewModels.Add(itemViewModel);
        }

        private void DepartmentStore_DepartmentStoreLoaded()
        {
            _departmentListingItemViewModels.Clear();

            foreach (Department department in Departments)
            {
                AddDepartment(department);
            }
        }

        protected override void Dispose()
        {
            base.Dispose();
        }
    }
}
