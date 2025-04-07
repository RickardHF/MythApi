using Microsoft.AspNetCore.Mvc;
using MythApi.Gods.Interfaces;
using MythApi.Common.Database.Models;
using MythApi.Gods.Models;

namespace MythApi.Endpoints.v1;
public static class Gods {
    public static void RegisterGodEndpoints(this IEndpointRouteBuilder endpoints) {
        var gods = endpoints.MapGroup("/api/v1/gods");

        gods.MapGet("", GetAllGodsHandler);
        gods.MapGet("{id}", GetGodByIdHandler);
        gods.MapGet("search/{name}", SearchGodsByNameHandler);
        gods.MapPost("", AddOrUpdateGodsHandler);
    }

    private static Task<IList<God>> GetAllGodsHandler(IGodRepository repository) => repository.GetAllGodsAsync();

    private static Task<God?> GetGodByIdHandler(int id, IGodRepository repository) => repository.GetGodAsync(new GodParameter(id));

    private static Task<IList<God>> SearchGodsByNameHandler(string name, IGodRepository repository, [FromQuery] bool includeAliases = false) =>
        repository.GetGodByNameAsync(new GodByNameParameter(name, includeAliases))
                  .ContinueWith(task => (IList<God>)task.Result);

    private static Task<List<God>> AddOrUpdateGodsHandler(List<GodInput> gods, IGodRepository repository) =>
        repository.AddOrUpdateGods(gods);
}