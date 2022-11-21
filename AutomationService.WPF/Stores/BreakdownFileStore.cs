using AutomationService.Domain.Commands.BreakdownFileCommands;
using AutomationService.Domain.Models;
using AutomationService.Domain.Queries.BreakdownFileQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutomationService.WPF.Stores
{
    public class BreakdownFileStore
    {
        readonly IGetAllBreakdownFilesQuery _getAllBreakdownFiles;
        readonly ICreateBreakdownFileCommand _createBreakdownFileCommand;
        readonly IDeleteBreakdownFileCommand _deleteBreakdownFileCommand;
        readonly IUpdateBreakdownFileCommand? _updateBreakdownFileCommand;

        readonly List<BreakdownFile> _breakdownFiles;
        public IEnumerable<BreakdownFile> BreakdownFiles => _breakdownFiles;

        public event Action BreakdownFilesLoaded;
        public event Action<BreakdownFile> BreakdownFilesAdded;
        public event Action<BreakdownFile> BreakdownFileUpdated;
        public event Action<Guid> BreakdownFileDeleted;

        public BreakdownFileStore(IGetAllBreakdownFilesQuery getAllBreakdownFiles, IDeleteBreakdownFileCommand deleteBreakdownFileCommand, ICreateBreakdownFileCommand createBreakdownFileCommand, IUpdateBreakdownFileCommand updateBreakdownFileCommand)
        {
            _getAllBreakdownFiles = getAllBreakdownFiles;
            _deleteBreakdownFileCommand = deleteBreakdownFileCommand;
            _createBreakdownFileCommand = createBreakdownFileCommand;
            _updateBreakdownFileCommand = updateBreakdownFileCommand;

            _breakdownFiles = new List<BreakdownFile>();
        }

        public async Task DeleteSelectedFile(Guid id)
        {
            await _deleteBreakdownFileCommand.DeleteBreakdownFile(id);

            _breakdownFiles.RemoveAll(b => b.Id == id);

            BreakdownFileDeleted?.Invoke(id);
        }

        public async Task LoadBreakdownFiles()
        {
            IEnumerable<BreakdownFile> breakdownFiles = await _getAllBreakdownFiles.GetAllBreakdownFiles();

            _breakdownFiles.Clear();
            _breakdownFiles.AddRange(breakdownFiles);

            BreakdownFilesLoaded?.Invoke();
        }

        public async Task AddBreakdownFiles(BreakdownFile breakdownFile)
        {
            await _createBreakdownFileCommand.CreateBreakdownFile(breakdownFile);

            _breakdownFiles.Add(breakdownFile);

            BreakdownFilesAdded?.Invoke(breakdownFile);
        }

        public async Task UpdateBrekdownFile(BreakdownFile breakdownFile)
        {
            await _updateBreakdownFileCommand.UpdateBreakdownFile(breakdownFile);

            int currentIndex = _breakdownFiles.FindIndex(e => e.Id == breakdownFile.Id);

            if (currentIndex != -1)
                _breakdownFiles[currentIndex] = breakdownFile;
            else
                _breakdownFiles.Add(breakdownFile);

            BreakdownFileUpdated?.Invoke(breakdownFile);
        }
    }
}
