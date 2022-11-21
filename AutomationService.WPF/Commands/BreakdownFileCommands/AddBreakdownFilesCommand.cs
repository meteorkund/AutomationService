using AutomationService.Domain.Models;
using AutomationService.EF;
using AutomationService.WPF.Converters;
using AutomationService.WPF.Stores;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutomationService.WPF.Commands.BreakdownFileCommands;

public class AddBreakdownFilesCommand : CommandBase
{
    readonly BreakdownFileStore _breakdownFileStore;
    readonly SelectedBreakdownStore _selectedBreakdownStore;
    readonly AutomationServiceDBContextFactory _contextFactory;



    public AddBreakdownFilesCommand(BreakdownFileStore breakdownFileStore, AutomationServiceDBContextFactory contextFactory, SelectedBreakdownStore selectedBreakdownStore)
    {
        _breakdownFileStore = breakdownFileStore;
        _contextFactory = contextFactory;
        _selectedBreakdownStore = selectedBreakdownStore;


    }


    public override async void Execute(object? parameter)
    {

        OpenFileDialog fileDialog = new();
        fileDialog.Multiselect = true;
        if (fileDialog.ShowDialog() == true)
        {
            foreach (var breakdownFiles in fileDialog.FileNames)
            {



                string dateTime = DateTime.Now.ToString("T");
                string dateTimeFile = dateTime
                    .Replace(".", string.Empty)
                    .Replace(":", string.Empty)
                    .Replace(" ", "-");


                string secilenDosya = breakdownFiles;
                string fileName = Path.GetFileNameWithoutExtension(secilenDosya);
                string fileExtension = Path.GetExtension(secilenDosya);

                string newFileName = $"{NameOperation.CharacterRegulatory(fileName)}-{dateTimeFile}{fileExtension}";
                string newFileNameNoExtension = Path.GetFileNameWithoutExtension(newFileName);

                string sourceFile = secilenDosya;
                string companyName = _selectedBreakdownStore.SelectedBreakdown.Customer.CompanyName;
                string newCompanyName = NameOperation.CharacterRegulatory(companyName);

                string targetPath = $"\\\\Desktop-1pm23j9\\TESTING\\{newCompanyName}";
                if (!Directory.Exists(targetPath))
                    Directory.CreateDirectory(targetPath);

                string destFile = Path.Combine(targetPath, newFileName);

                BreakdownFile breakdownFile = new BreakdownFile
                {
                    Id = Guid.NewGuid(),
                    BreakdownId = _selectedBreakdownStore.SelectedBreakdown.Id,
                    FileName = newFileNameNoExtension,
                    FileExtension = fileExtension,
                    Path = destFile
                };

                try
                {
                    using (FileStream fileStreamSource = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.Asynchronous | FileOptions.SequentialScan))
                    {
                        using (FileStream fileStreamDestination = new FileStream(destFile, FileMode.CreateNew, FileAccess.Write, FileShare.None, 4096, FileOptions.Asynchronous | FileOptions.SequentialScan))
                        {
                            await fileStreamSource.CopyToAsync(fileStreamDestination);
                        }
                    }

                    await _breakdownFileStore.AddBreakdownFiles(breakdownFile);

                }
                catch (Exception)
                {
                    MessageBox.Show("Aynı dosya adına sahip olan başka bir dosya var!", "Yükleme Hatası!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            //}

            //BreakdownFile breakdownFile = new BreakdownFile
            //{
            //    Id= lastBreakdownFileId,
            //    BreakdownId = breakdownFile.BreakdownId,
            //    FileName = breakdownFile.FileName,
            //    FileExtension = breakdownFile.FileExtension,
            //    Path = breakdownFile.Path,
            //};

        }
    }
}
