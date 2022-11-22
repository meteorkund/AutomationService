using AutomationService.Domain.Commands.BreakdownCommands;
using AutomationService.Domain.Models;
using AutomationService.Domain.Queries.BrekdownQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.WPF.Stores;

public class BreakdownStore
{
    readonly IGetAllBreakdownsQuery _getAllBreakdownsQuery;
    readonly ICreateBreakdownCommand _createBreakdownCommand;
    readonly IUpdateBreakdownCommand _updateBreakdownCommand;
    readonly IDeleteBreakdownCommand _deleteBreakdownCommand;

    readonly List<Breakdown> _breakdowns;
    public IEnumerable<Breakdown> Breakdowns => _breakdowns;

    public event Action BreakdownsLoaded;
    public event Action<Breakdown> BreakdownAdded;
    public event Action<Breakdown> BreakdownUpdated;
    public event Action<Guid> BreakdownDeleted;


    public BreakdownStore(IGetAllBreakdownsQuery getAllBreakdownsQuery, ICreateBreakdownCommand createBreakdownCommand, IUpdateBreakdownCommand updateBreakdownCommand, IDeleteBreakdownCommand deleteBreakdownCommand)
    {
        _getAllBreakdownsQuery = getAllBreakdownsQuery;
        _createBreakdownCommand = createBreakdownCommand;
        _updateBreakdownCommand = updateBreakdownCommand;
        _deleteBreakdownCommand = deleteBreakdownCommand;

        _breakdowns = new List<Breakdown>();
    }

    public async Task Add(Breakdown breakdown)
    {
        await _createBreakdownCommand.Create(breakdown);

        _breakdowns.Add(breakdown);

        BreakdownAdded?.Invoke(breakdown);
    }

    public async Task Update(Breakdown breakdown)
    {
        await _updateBreakdownCommand.Update(breakdown);

        int currentIndex = _breakdowns.FindIndex(e => e.Id == breakdown.Id);

        if (currentIndex != -1)
            _breakdowns[currentIndex] = breakdown;
        else
            _breakdowns.Add(breakdown);

        BreakdownUpdated?.Invoke(breakdown);
    }

    public async Task LoadBreakdowns()
    {
        IEnumerable<Breakdown> breakdowns = await _getAllBreakdownsQuery.GetAllBreakdowns();

        _breakdowns.Clear();
        _breakdowns.AddRange(breakdowns);

        BreakdownsLoaded?.Invoke();
    }

    public async Task Delete(Guid id)
    {
        await _deleteBreakdownCommand.DeleteBreakdown(id);

        _breakdowns.RemoveAll(e => e.Id == id);

        BreakdownDeleted?.Invoke(id);
    }

}
