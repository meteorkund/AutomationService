﻿using AutomationService.Domain.Models;
using AutomationService.EF.DTOs;
using AutomationService.WPF.Commands;
using AutomationService.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomationService.WPF.ViewModels.BreakdownViewModels
{
    public class EditBreakdownViewModel : ViewModelBase
    {
        public int BreakdownId { get; }
        public BreakdownDetailsFormViewModel BreakdownDetailsFormViewModel { get; }

        public EditBreakdownViewModel(Breakdown breakdown, BreakdownStore breakdownStore, ModalNavigationStore modalNavigationStore, BreakdownSolverStore breakdownSolverStore, DepartmentStore departmentStore, SectorStore sectorStore, EmployeeStore employeeStore)
        {
            BreakdownId = breakdown.Id;

            ICommand submitCommand = new EditBreakdownCommand(this, breakdownStore, modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            BreakdownDetailsFormViewModel = new BreakdownDetailsFormViewModel(submitCommand, cancelCommand, breakdownSolverStore, departmentStore, sectorStore, employeeStore)
            {
                CompanyName = breakdown.Customer.CompanyName,
                Country = breakdown.Customer.Country,
                IsElectrical = breakdown.IsElectrical,
                IsMechanical = breakdown.IsMechanical,
                Cause = breakdown.Cause,
                Service = breakdown.Service,

                CreatorName = breakdown.Employee.NameSurname,

                SelectedBreakdownSolverValue = breakdown.BreakdownSolver.Id,
                SelectedDepartmentValue = breakdown.Department.Id,
                SelectedSectorValue = breakdown.Sector.Id,
            };
        }
    }
}
