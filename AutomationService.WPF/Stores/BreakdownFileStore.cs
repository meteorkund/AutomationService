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
        readonly IDeleteBreakdownFileCommand _deleteBreakdownFileCommand;

        readonly List<BreakdownFile> _breakdownFiles;
        public IEnumerable<BreakdownFile> BreakdownFiles => _breakdownFiles;

        public event Action BreakdownFilesLoaded;
        public event Action<int> BreakdownFileDeleted;

        public BreakdownFileStore(IGetAllBreakdownFilesQuery getAllBreakdownFiles, IDeleteBreakdownFileCommand deleteBreakdownFileCommand)
        {
            _getAllBreakdownFiles = getAllBreakdownFiles;
            _deleteBreakdownFileCommand = deleteBreakdownFileCommand;

            _breakdownFiles = new List<BreakdownFile>();
        }

        public async Task DeleteSelectedFile(int id)
        {
            await _deleteBreakdownFileCommand.DeleteBreakdownFile(id);

            _breakdownFiles.RemoveAll(b=> b.Id == id);

            BreakdownFileDeleted?.Invoke(id);
        }

        public async Task LoadBreakdownFiles()
        {
            IEnumerable<BreakdownFile> breakdownFiles = await _getAllBreakdownFiles.GetAllBreakdownFiles();

            _breakdownFiles.Clear();
            _breakdownFiles.AddRange(breakdownFiles);

            BreakdownFilesLoaded?.Invoke();
        }
    }
}
