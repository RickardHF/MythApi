using Microsoft.EntityFrameworkCore;
using MythApi.Gods.Interfaces;
using MythApi.Common.Database.Models;
using MythApi.Common.Database;

namespace MythApi.Gods.DBRepositories;

public class GodRepository : IGodRepository
{
    private readonly AppDbContext _context;

    public GodRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<God>> AddOrUpdateGods(List<God> gods)
    {
        var existingGods = gods.Where(god => _context.Gods.Any(existing => god.Id == existing.Id)).ToList();
        var newGods = gods.Where(god => !_context.Gods.Any(existing => god.Id == existing.Id)).ToList();

        await _context.Gods.AddRangeAsync(newGods);
        _context.Gods.UpdateRange(existingGods);
        await _context.SaveChangesAsync();
        return await _context.Gods.ToListAsync();
    }

    public async Task<IList<God>> GetAllGodsAsync()
    {
        return await _context.Gods.ToListAsync();
    }

    public async Task<God> GetGodAsync(GodParameter parameter)
    {
        return await _context.Gods.FirstAsync(x => x.Id == parameter.Id);
    }

    public Task<List<God>> GetGodByNameAsync(GodByNameParameter parameter)
    {
        return Task.FromResult(_context.Gods.Where(god => god.Name.Contains(parameter.Name)).ToList());
    }
}