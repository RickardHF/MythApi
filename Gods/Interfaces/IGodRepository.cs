using MythApi.Gods.Models;

namespace MythApi.Gods.Interfaces;

public interface IGodRepository{
    public Task<IList<GodDbObject>> GetAllGodsAsync();

    public Task<GodDbObject> GetGodAsync(GodParameter parameter);

    public Task<List<GodDbObject>> GetGodByNameAsync(GodByNameParameter parameter);

    public Task<List<GodDbObject>> AddOrUpdateGods(List<GodDbObject> gods);
}