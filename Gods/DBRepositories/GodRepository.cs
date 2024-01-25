using Microsoft.EntityFrameworkCore;
using MythApi.Gods.Interfaces;
using MythApi.Gods.Models;

namespace MythApi.Gods.DBRepositories;

public class GodRepository : IGodRepository
{
    private readonly AppDBContext _context;

    public GodRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<List<GodDbObject>> AddOrUpdateGods(List<GodDbObject> gods)
    {
        var existingGods = gods.Where(god => _context.Gods.Any(existing => god.Id == existing.Id)).ToList();
        var newGods = gods.Where(god => !_context.Gods.Any(existing => god.Id == existing.Id)).ToList();

        await _context.Gods.AddRangeAsync(newGods);
        _context.Gods.UpdateRange(existingGods);
        await _context.SaveChangesAsync();
        return await _context.Gods.ToListAsync();
    }

    public async Task<IList<GodDbObject>> GetAllGodsAsync()
    {
        return await _context.Gods.ToListAsync();
    }

    public async Task<GodDbObject> GetGodAsync(GodParameter parameter)
    {
        return await _context.Gods.FirstAsync(x => x.Id == parameter.Id);
    }

    public Task<List<GodDbObject>> GetGodByNameAsync(GodByNameParameter parameter)
    {
        return Task.FromResult(_context.Gods.Where(god => god.Name.Contains(parameter.Name)).ToList());
    }
}