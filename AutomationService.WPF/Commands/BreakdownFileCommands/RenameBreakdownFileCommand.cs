using AutomationService.Domain.Models;
using AutomationService.WPF.Converters;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.BreakdownFileViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace AutomationService.WPF.Commands.BreakdownFileCommands
{
    public class RenameBreakdownFileCommand : AsyncCommandBase
    {
        readonly SelectedBreakdownFileStore _selectedBreakdownFileStore;
        readonly BreakdownFileListingItemViewModel _breakdownFileListingItemViewModel;
        readonly BreakdownFileStore _breakdownFileStore;


        public RenameBreakdownFileCommand(BreakdownFileListingItemViewModel breakdownFileListingItemViewModel, BreakdownFileStore breakdownFileStore, SelectedBreakdownFileStore selectedBreakdownFileStore)
        {
            _breakdownFileListingItemViewModel = breakdownFileListingItemViewModel;
            _breakdownFileStore = breakdownFileStore;
            _selectedBreakdownFileStore = selectedBreakdownFileStore;
        }

        string filePath => _breakdownFileListingItemViewModel?.FilePath;


        public BreakdownFile SelectedBreakdownFile => _selectedBreakdownFileStore?.SelectedBreakdownFile;

        public override async Task ExecuteAsync(object parameter)
        {
            string rootPath = Path.GetDirectoryName(filePath);

            string fileExtension = Path.GetExtension(filePath);
            var newFileName = CustomInputControl.GetNewFileName();

            string destPath = $"{newFileName}{fileExtension}";

            if (!string.IsNullOrEmpty(newFileName))
            {
                var renamedFileName = Path.Combine(rootPath, destPath);

                BreakdownFile breakdownFile = new BreakdownFile
                {
                    Id = SelectedBreakdownFile.Id,
                    BreakdownId = SelectedBreakdownFile.BreakdownId,
                    FileName = newFileName,
                    FileExtension = SelectedBreakdownFile.FileExtension,
                    Path = renamedFileName,
                    CreatedDate = SelectedBreakdownFile.CreatedDate
                };


                try
                {
                    File.Move(filePath, renamedFileName);

                    await _breakdownFileStore.UpdateBrekdownFile(breakdownFile);
                }


                catch
                {
                    System.Windows.MessageBox.Show("DOSYA YENİDEN ADLANDIRMADA HATAYLA KARŞILAŞILDI!");

                }
            }

        }

    }
}

