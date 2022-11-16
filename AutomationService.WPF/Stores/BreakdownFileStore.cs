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

        readonly List<BreakdownFile> _breakdownFiles;
        public IEnumerable<BreakdownFile> BreakdownFiles => _breakdownFiles;

        public event Action BreakdownFilesLoaded;

        public BreakdownFileStore(IGetAllBreakdownFilesQuery getAllBreakdownFiles)
        {
            _getAllBreakdownFiles = getAllBreakdownFiles;
            _breakdownFiles = new List<BreakdownFile>();
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
