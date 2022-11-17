using AutomationService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.ViewModels.BreakdownFileViewModels
{
    public class BreakdownFileListingItemViewModel : ViewModelBase
    {
        public BreakdownFile BreakdownFile { get; private set; }

        public BreakdownFileListingItemViewModel(BreakdownFile breakdownFile)
        {
            BreakdownFile = breakdownFile;
        }
        public int BreakdownFileId => BreakdownFile.Id;
        public int BreakdownId => BreakdownFile.BreakdownId;
        public string FileName => BreakdownFile.FileName;

        public string FileExtension => BreakdownFile.FileExtension;
        public string FilePath => BreakdownFile.Path;


    }
}
