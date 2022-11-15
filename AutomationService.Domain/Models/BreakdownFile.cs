using AutomationService.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.Domain.Models
{
    public class BreakdownFile : BaseEntity
    {
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string Path { get; set; }
        public Breakdown Breakdown { get; set; }
    }
}
