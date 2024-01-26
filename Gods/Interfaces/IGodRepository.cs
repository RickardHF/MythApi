using MythApi.Common.Database.Models;
using MythApi.Gods.Database;

namespace MythApi.Gods.Interfaces;

public interface IGodRepository{
    public Task<IList<God>> GetAllGodsAsync();

    public Task<God> GetGodAsync(GodParameter parameter);

    public Task<List<God>> GetGodByNameAsync(GodByNameParameter parameter);

    public Task<List<God>> AddOrUpdateGods(List<God> gods);
}