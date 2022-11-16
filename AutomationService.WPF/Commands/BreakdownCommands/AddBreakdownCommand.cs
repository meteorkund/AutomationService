using AutomationService.Domain.Models;
using AutomationService.Domain.Models.Common;
using AutomationService.EF;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.BreakdownViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutomationService.WPF.Commands
{
    public class AddBreakdownCommand : AsyncCommandBase
    {
        readonly ModalNavigationStore _modalNavigationStore;
        readonly BreakdownStore _BreakdownStore;
        readonly AddBreakdownViewModel _addBreakdownViewModel;
        readonly AutomationServiceDBContextFactory _contextFactory;

        int lastBreakdownId;
        public AddBreakdownCommand(AddBreakdownViewModel addBreakdownViewModel, BreakdownStore breakdownStore, ModalNavigationStore modalNavigationStore, AutomationServiceDBContextFactory contextFactory)
        {
            _modalNavigationStore = modalNavigationStore;
            _BreakdownStore = breakdownStore;
            _addBreakdownViewModel = addBreakdownViewModel;
            _contextFactory = contextFactory;

            try
            {
                using (AutomationServiceDBContext context = _contextFactory.Create())
                {
                    var lastBreakdown = context.Employees.ToList().Last();
                    lastBreakdownId = lastBreakdown.Id;
                }
            }
            catch
            {
                lastBreakdownId = 0;
            }
        }

        public override async Task ExecuteAsync(object parameter)
        {
            BreakdownDetailsFormViewModel formViewModel = _addBreakdownViewModel.BreakdownDetailsFormViewModel;

            formViewModel.ErrorMessage = null;

            Breakdown breakdown = new Breakdown
            {
                Id = lastBreakdownId + 1,
                Status = true,

                Department = formViewModel.Department,
                Sector = formViewModel.Sector,

                IsElectrical = formViewModel.IsElectrical,
                IsMechanical = formViewModel.IsMechanical,

                Cause = formViewModel.Cause,
                Service = formViewModel.Service,

                Customer = new Customer { Id = 2, CompanyName = formViewModel.CompanyName, Country = formViewModel.Country }


            };




            try
            {
                await _BreakdownStore.Add(breakdown);


                _modalNavigationStore.Close();

            }
            catch (Exception)
            {
                formViewModel.ErrorMessage = "Servis kaydı düzenlenmesi sırasında hata oluştu. Daha sonra tekrar deneyiniz.";
            }
            finally
            {
                //formViewModel.IsSubmitting = false;
            }
        }
    }
}
