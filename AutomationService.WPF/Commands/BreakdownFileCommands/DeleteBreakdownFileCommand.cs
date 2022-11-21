using AutomationService.Domain.Models;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.BreakdownFileViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutomationService.WPF.Commands.BreakdownFileCommands
{
    public class DeleteBreakdownFileCommand : AsyncCommandBase
    {
        readonly BreakdownFileStore _breakdownFileStore;
        readonly BreakdownFileListingItemViewModel _breakdownFileListingItemViewModel;

        public DeleteBreakdownFileCommand(BreakdownFileListingItemViewModel breakdownFileListingItemViewModel, BreakdownFileStore breakdownFileStore)
        {
            _breakdownFileListingItemViewModel = breakdownFileListingItemViewModel;
            _breakdownFileStore = breakdownFileStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            string message = "Dosyayı silmek istediğinize emin misiniz";
            string caption = "Dikkat!";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning;


            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                _breakdownFileListingItemViewModel.IsDeletingFile = true;
                BreakdownFile breakdownFile = _breakdownFileListingItemViewModel.BreakdownFile;

                string filePath = breakdownFile.Path;

                try
                {
                    await _breakdownFileStore.DeleteSelectedFile(breakdownFile.Id);

                    if (File.Exists(filePath))
                    {
                        using (FileStream fileStream = new FileStream(filePath, FileMode.Truncate, FileAccess.Write, FileShare.Delete, 4096, true))
                        {
                            fileStream.Flush();
                            File.Delete(filePath);
                        }
                    }
                    else
                        MessageBox.Show("Veritabanından Silindi Fakat Fiziki Olarak Dosya Bulunamadı.", "FİZİKİ SİLME SIRASINDA HATA", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
                catch (Exception)
                {
                    MessageBox.Show("Dosya silinirken hatayla karşılaşıldı!", "Hata!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    _breakdownFileListingItemViewModel.IsDeletingFile = false;
                }
            }
        }
    }
}
