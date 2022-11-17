using AutomationService.Domain.Models;
using AutomationService.WPF.Commands.BreakdownFileCommands;
using AutomationService.WPF.Stores;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace AutomationService.WPF.ViewModels.BreakdownFileViewModels;

public class BreakdownFileListingViewModel : ViewModelBase
{
    readonly ObservableCollection<BreakdownFileListingItemViewModel> _breakdownFileListingItemViewModels;
    public IEnumerable<BreakdownFileListingItemViewModel> BreakdownFileListingItemViewModels => _breakdownFileListingItemViewModels;
    readonly BreakdownFileStore _breakdownFileStore;

    public ICommand LoadBreakdownFilesCommand { get; }


    string filePath = "xx";
    public BreakdownFileListingViewModel(BreakdownFileStore breakdownFileStore)
    {
        _breakdownFileStore = breakdownFileStore;


        _breakdownFileListingItemViewModels = new ObservableCollection<BreakdownFileListingItemViewModel>();

        LoadBreakdownFilesCommand = new LoadBreakdownFilesCommand(this, breakdownFileStore);


        _breakdownFileStore.BreakdownFilesLoaded += BreakdownFileStore_BreakdownFilesLoaded;


    }


    public static BreakdownFileListingViewModel LoadViewModel(BreakdownFileStore breakdownFileStore)
    {
        BreakdownFileListingViewModel viewModel = new BreakdownFileListingViewModel(breakdownFileStore);

        viewModel.LoadBreakdownFilesCommand.Execute(null);

        return viewModel;
    }

    private void BreakdownFileStore_BreakdownFilesLoaded()
    {
        _breakdownFileListingItemViewModels.Clear();
        foreach (BreakdownFile breakdownFile in _breakdownFileStore.BreakdownFiles)
        {
            AddBreakdownFile(breakdownFile);
        }
    }

    private void AddBreakdownFile(BreakdownFile breakdownFile)
    {
        BreakdownFileListingItemViewModel itemViewModel = new BreakdownFileListingItemViewModel(breakdownFile);
        _breakdownFileListingItemViewModels.Add(itemViewModel);
    }

    protected override void Dispose()
    {
        _breakdownFileStore.BreakdownFilesLoaded -= BreakdownFileStore_BreakdownFilesLoaded;

        base.Dispose();
    }
}
