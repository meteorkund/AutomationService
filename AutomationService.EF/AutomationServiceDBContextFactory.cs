using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.EF
{
    public class AutomationServiceDBContextFactory
    {
        readonly DbContextOptions _options;

        public AutomationServiceDBContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public AutomationServiceDBContext Create()
        {
            return new AutomationServiceDBContext(_options);
        }
    }
}
