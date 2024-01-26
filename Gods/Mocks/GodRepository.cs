using MythApi.Gods.Interfaces;
using MythApi.Common.Database.Models;

namespace MythApi.Gods.Mocks;

public class GodRepository : IGodRepository
{
    private List<God> gods = new List<God>{
        new() {
            Name = "Zeus",
            Description = "Zeus is the sky and thunder god in ancient Greek religion, who rules as king of the gods of Mount Olympus.",
            Mythology = new () { Id = 1, Name = "Greek" }
        },
        new() {
            Name = "Hades",
            Description = "Hades is the god of the dead and the king of the underworld, with which his name became synonymous.",
            Mythology = new () { Id = 1, Name = "Greek" }
        },
        new() {
            Name = "Poseidon",
            Description = "Poseidon was god of the sea, earthquakes, storms, and horses and is considered one of the most bad-tempered, moody and greedy Olympian gods.",
            Mythology = new () { Id = 1, Name = "Greek" }
        },
        new() {
            Name = "Athena",
            Description = "Athena is the goddess of handicrafts, useful arts, and battle strategy. She is the patron goddess of heroic endeavor.",
            Mythology = new () { Id = 1, Name = "Greek" }
        },
        new() {
            Name = "Odin",
            Description = "Odin is a god in Norse mythology, who was associated with healing, death, knowledge, sorcery, poetry, battle and the runic alphabet.",
            Mythology = new () { Id = 2, Name = "Norse" }
        }
    };

    public Task<List<God>> AddOrUpdateGods(List<God> gods)
    {
        this.gods.AddRange(gods);
        return Task.FromResult(gods);
    }

    public Task<IList<God>> GetAllGodsAsync()
    {
        return Task.FromResult(gods as IList<God>);
    }

    public Task<God> GetGodAsync(GodParameter parameter)
    {
        return Task.FromResult(gods[parameter.Id]);
    }

    public Task<List<God>> GetGodByNameAsync(GodByNameParameter parameter)
    {
        return Task.FromResult(gods.Where(god => god.Name.Contains(parameter.Name)).ToList());
    }
}