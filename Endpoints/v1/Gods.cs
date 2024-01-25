using Microsoft.AspNetCore.Mvc;
using MythApi.Gods.Interfaces;
using MythApi.Gods.Models;
public static class Gods {
    public static void RegisterGodEndpoints(this IEndpointRouteBuilder endpoints) {
        
        var gods = endpoints.MapGroup("/api/v1/gods");


        gods.MapGet("", GetAlllGods);
        gods.MapGet("{id}", (int id, IGodRepository repository) => repository.GetGodAsync(new GodParameter(id)));
        gods.MapGet("search/{name}", (string name, IGodRepository repository, [FromQuery] bool includeAliases = false) => repository.GetGodByNameAsync(new GodByNameParameter(name, includeAliases)));
        gods.MapPost("", AddOrUpdateGods);
    }

    public static Task<List<GodDbObject>> AddOrUpdateGods(List<GodDbObject> gods, IGodRepository repository) => repository.AddOrUpdateGods(gods);

    public static Task<IList<GodDbObject>> GetAlllGods(IGodRepository repository) => repository.GetAllGodsAsync();
}