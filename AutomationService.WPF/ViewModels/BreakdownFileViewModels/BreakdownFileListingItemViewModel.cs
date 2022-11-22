using AutomationService.Domain.Models;
using AutomationService.Domain.Models.Common;
using AutomationService.WPF.Commands.BreakdownFileCommands;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.BreakdownViewModels;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AutomationService.WPF.ViewModels.BreakdownFileViewModels
{
    public class BreakdownFileListingItemViewModel : ViewModelBase
    {
        public BreakdownFile BreakdownFile { get; private set; }

        public ICommand OpenSelectedFileCommand { get; }
        public ICommand RenameBreakdownFileCommand { get; }
        public ICommand DeleteSelectedFileCommand { get; }


        readonly SelectedBreakdownFileStore _selectedBreakdownFileStore;
        public BreakdownFileListingItemViewModel(BreakdownFile breakdownFile, SelectedBreakdownFileStore selectedBreakdownFileStore, BreakdownFileStore breakdownFileStore)
        {
            BreakdownFile = breakdownFile;
            _selectedBreakdownFileStore = selectedBreakdownFileStore;

            OpenSelectedFileCommand = new OpenBreakdownFileCommand(selectedBreakdownFileStore);
            RenameBreakdownFileCommand = new RenameBreakdownFileCommand(this, breakdownFileStore, selectedBreakdownFileStore);
            DeleteSelectedFileCommand = new DeleteBreakdownFileCommand(this, breakdownFileStore);
        }




        public Guid BreakdownFileId => BreakdownFile.Id;
        public Guid BreakdownId => BreakdownFile.BreakdownId;
        public string FileName => BreakdownFile.FileName;

        public string FileExtension => BreakdownFile.FileExtension;
        public string FilePath => BreakdownFile.Path;
        public string CreatedDateTime => BreakdownFile.CreatedDate.ToString();

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

        public void BreakdownFileUpdate(BreakdownFile breakdownFile)
        {
            BreakdownFile = breakdownFile;
            OnPropertyChanged(nameof(BreakdownId));
            OnPropertyChanged(nameof(BreakdownFileId));
            OnPropertyChanged(nameof(FileName));
            OnPropertyChanged(nameof(FileExtension));
            OnPropertyChanged(nameof(FilePath));
            OnPropertyChanged(nameof(CreatedDateTime));

        }



    }
}
