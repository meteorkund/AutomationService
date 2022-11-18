using AutomationService.Domain.Models;
using AutomationService.WPF.Commands.BreakdownFileCommands;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.BreakdownViewModels;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AutomationService.WPF.ViewModels.BreakdownFileViewModels
{
    public class BreakdownFileListingItemViewModel : ViewModelBase
    {
        public BreakdownFile BreakdownFile { get; private set; }

        public ICommand OpenSelectedFileCommand { get; }
        public ICommand DeleteSelectedFileCommand { get; }


        readonly SelectedBreakdownFileStore _selectedBreakdownFileStore;
        public BreakdownFileListingItemViewModel(BreakdownFile breakdownFile, SelectedBreakdownFileStore selectedBreakdownFileStore, BreakdownFileStore breakdownFileStore)
        {
            BreakdownFile = breakdownFile;
            _selectedBreakdownFileStore= selectedBreakdownFileStore;

            OpenSelectedFileCommand = new OpenBreakdownFileCommand(selectedBreakdownFileStore);
            DeleteSelectedFileCommand = new DeleteBreakdownFileCommand(this, breakdownFileStore);
        }




        public int BreakdownFileId => BreakdownFile.Id;
        public int BreakdownId => BreakdownFile.BreakdownId;
        public string FileName => BreakdownFile.FileName;

        public string FileExtension => BreakdownFile.FileExtension;
        public string FilePath => BreakdownFile.Path;

        private bool _isDeletingFile;

        public bool IsDeletingFile
        {
            get { return _isDeletingFile; }
            set
            {
                _isDeletingFile = value;

                OnPropertyChanged(nameof(IsDeletingFile));
            }
        }



    }
}
