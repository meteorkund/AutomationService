using AutomationService.Domain.Queries;
using Microsoft.EntityFrameworkCore;
using AutomationService.Domain.Models.Common;
using AutomationService.EF.DTOs;

namespace AutomationService.EF.Queries;

public class GetAllSectorsQuery : IGetAllSectorsQuery
{
    readonly AutomationServiceDBContextFactory _contextFactory;

    public GetAllSectorsQuery(AutomationServiceDBContextFactory contextFactor)
    {
        _contextFactory = contextFactor;
    }

    public async Task<IEnumerable<Sector>> GetAllSectors()
    {
        using (AutomationServiceDBContext context = _contextFactory.Create())
        {
            IEnumerable<SectorDTO> sectorDTOs = await context.Sectors.ToListAsync();
            return sectorDTOs.Select(d => new Sector(
                d.Id,
                d.SectorName
                ));
        }
    }
}
