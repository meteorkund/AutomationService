using AutomationService.Domain.Models;
using AutomationService.WPF.Commands.BreakdownFileCommands;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.BreakdownViewModels;
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
    readonly SelectedBreakdownFileStore _selectedBreakdownFileStore;
    readonly BreakdownFile _breakdownFile;
    public ICommand LoadBreakdownFilesCommand { get; }

    readonly BreakdownFileListingItemViewModel _breakdownFileListingItemViewModel;

    public BreakdownFileListingViewModel(BreakdownFileStore breakdownFileStore,SelectedBreakdownFileStore selectedBreakdownFileStore)
    {
        _breakdownFileStore = breakdownFileStore;
        _selectedBreakdownFileStore = selectedBreakdownFileStore;


        _breakdownFileListingItemViewModels = new ObservableCollection<BreakdownFileListingItemViewModel>();

        LoadBreakdownFilesCommand = new LoadBreakdownFilesCommand(this, breakdownFileStore);

        _breakdownFileListingItemViewModel = new BreakdownFileListingItemViewModel(_breakdownFile, selectedBreakdownFileStore);

        _breakdownFileStore.BreakdownFilesLoaded += BreakdownFileStore_BreakdownFilesLoaded;

    }

    private BreakdownFileListingItemViewModel _selectedBreakdownFile;

    public BreakdownFileListingItemViewModel SelectedBreakdownFile
    {
        get { return _selectedBreakdownFile; }
        set
        {
            _selectedBreakdownFile = value;
            _selectedBreakdownFileStore.SelectedBreakdownFile = value?.BreakdownFile;
            OnPropertyChanged(nameof(SelectedBreakdownFile));
        }
    }

    public static BreakdownFileListingViewModel LoadViewModel(BreakdownFileStore breakdownFileStore, SelectedBreakdownFileStore selectedBreakdownFileStore)
    {
        BreakdownFileListingViewModel viewModel = new BreakdownFileListingViewModel(breakdownFileStore, selectedBreakdownFileStore);

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
        BreakdownFileListingItemViewModel itemViewModel = new BreakdownFileListingItemViewModel(breakdownFile, _selectedBreakdownFileStore);
        _breakdownFileListingItemViewModels.Add(itemViewModel);
    }

    protected override void Dispose()
    {
        _breakdownFileStore.BreakdownFilesLoaded -= BreakdownFileStore_BreakdownFilesLoaded;

        base.Dispose();
    }
}
