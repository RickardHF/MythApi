using MythApi.Gods.Models;

namespace MythApi.Gods.Interfaces;

public interface IGodRepository{
    public Task<IList<IGod>> GetAllGodsAsync();

    public Task<IGod> GetGodAsync(GodParameter parameter);

    public Task<List<IGod>> GetGodByNameAsync(GodByNameParameter parameter);
}