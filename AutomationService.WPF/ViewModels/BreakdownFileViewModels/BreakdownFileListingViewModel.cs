using AutomationService.Domain.Models;
using AutomationService.WPF.Commands.BreakdownFileCommands;
using AutomationService.WPF.Stores;
using AutomationService.WPF.ViewModels.BreakdownViewModels;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace AutomationService.WPF.ViewModels.BreakdownFileViewModels;

public class BreakdownFileListingViewModel : ViewModelBase
{
    readonly ObservableCollection<BreakdownFileListingItemViewModel> _breakdownFileListingItemViewModels;
    readonly BreakdownFileListingItemViewModel _breakdownFileListingItemViewModel;


    public IEnumerable<BreakdownFileListingItemViewModel> BreakdownFileListingItemViewModels => _breakdownFileListingItemViewModels;
    public IEnumerable<BreakdownFileListingItemViewModel> GroupedByBreakdownFiles => BreakdownFileListingItemViewModels.Where(x => x.BreakdownId == _selectedBreakdownStore?.SelectedBreakdown?.Id).ToList();

    readonly SelectedBreakdownStore _selectedBreakdownStore;

    readonly BreakdownFileStore _breakdownFileStore;
    readonly SelectedBreakdownFileStore _selectedBreakdownFileStore;
    readonly BreakdownFile _breakdownFile;
    public ICommand LoadBreakdownFilesCommand { get; }




    public BreakdownFileListingViewModel(BreakdownFileStore breakdownFileStore,
                                         SelectedBreakdownFileStore selectedBreakdownFileStore,
                                         SelectedBreakdownStore selectedBreakdownStore)
    {
        _breakdownFileStore = breakdownFileStore;
        _selectedBreakdownFileStore = selectedBreakdownFileStore;
        _selectedBreakdownStore = selectedBreakdownStore;


        _breakdownFileListingItemViewModels = new ObservableCollection<BreakdownFileListingItemViewModel>();

        LoadBreakdownFilesCommand = new LoadBreakdownFilesCommand(this, breakdownFileStore);

        _breakdownFileListingItemViewModel = new BreakdownFileListingItemViewModel(_breakdownFile, selectedBreakdownFileStore, breakdownFileStore);

        _breakdownFileStore.BreakdownFilesAdded += BreakdownFileStore_BreakdownFilesAdded;
        _breakdownFileStore.BreakdownFilesLoaded += BreakdownFileStore_BreakdownFilesLoaded;
        _breakdownFileStore.BreakdownFileUpdated += BreakdownFileStore_BreakdownFileUpdated;
        _breakdownFileStore.BreakdownFileDeleted += BreakdownFileStore_BreakdownFileDeleted;

        _selectedBreakdownStore.SelectedBreakdownChanged += SelectedBreakdownStore_SelectedBreakdownChanged;

    }

    private void BreakdownFileStore_BreakdownFilesAdded(BreakdownFile breakdownFile)
    {
        AddBreakdownFile(breakdownFile);
        OnPropertyChanged(nameof(GroupedByBreakdownFiles));
    }

    private void BreakdownFileStore_BreakdownFileDeleted(Guid id)
    {
        BreakdownFileListingItemViewModel itemViewModel = _breakdownFileListingItemViewModels.FirstOrDefault(b => b.BreakdownFile?.Id == id);

        if (itemViewModel != null)
        {
            _breakdownFileListingItemViewModels.Remove(itemViewModel);
            OnPropertyChanged(nameof(GroupedByBreakdownFiles));
        }
    }

    private void SelectedBreakdownStore_SelectedBreakdownChanged()
    {
        OnPropertyChanged(nameof(GroupedByBreakdownFiles));
        ;
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

    public static BreakdownFileListingViewModel LoadViewModel(BreakdownFileStore breakdownFileStore, SelectedBreakdownFileStore selectedBreakdownFileStore, SelectedBreakdownStore selectedBreakdownStore)
    {
        BreakdownFileListingViewModel viewModel = new BreakdownFileListingViewModel(breakdownFileStore, selectedBreakdownFileStore, selectedBreakdownStore);

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
        BreakdownFileListingItemViewModel itemViewModel = new BreakdownFileListingItemViewModel(breakdownFile, _selectedBreakdownFileStore, _breakdownFileStore);
        _breakdownFileListingItemViewModels.Add(itemViewModel);
    }

    private void BreakdownFileStore_BreakdownFileUpdated(BreakdownFile breakdownFile)
    {
        BreakdownFileListingItemViewModel breakdownFileViewModel = _breakdownFileListingItemViewModels.FirstOrDefault(e => e.BreakdownFile.Id == breakdownFile.Id);

        if (breakdownFileViewModel != null)
            breakdownFileViewModel.BreakdownFileUpdate(breakdownFile);
    }


    protected override void Dispose()
    {
        _breakdownFileStore.BreakdownFilesAdded -= BreakdownFileStore_BreakdownFilesAdded;
        _breakdownFileStore.BreakdownFilesLoaded -= BreakdownFileStore_BreakdownFilesLoaded;
        _breakdownFileStore.BreakdownFileUpdated -= BreakdownFileStore_BreakdownFileUpdated;
        _breakdownFileStore.BreakdownFileDeleted -= BreakdownFileStore_BreakdownFileDeleted;


        _selectedBreakdownStore.SelectedBreakdownChanged -= SelectedBreakdownStore_SelectedBreakdownChanged;


        base.Dispose();
    }
}
