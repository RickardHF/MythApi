using MythApi.Gods.Interfaces;
using MythApi.Gods.Models;

namespace MythApi.Gods.Mocks;

public class GodRepository : IGodRepository
{
    private List<GodDbObject> gods = new List<GodDbObject>{
        new() {
            Name = "Zeus",
            Description = "Zeus is the sky and thunder god in ancient Greek religion, who rules as king of the gods of Mount Olympus.",
            Mythology = Mythology.Greek
        },
        new() {
            Name = "Hades",
            Description = "Hades is the god of the dead and the king of the underworld, with which his name became synonymous.",
            Mythology = Mythology.Greek
        },
        new() {
            Name = "Poseidon",
            Description = "Poseidon was god of the sea, earthquakes, storms, and horses and is considered one of the most bad-tempered, moody and greedy Olympian gods.",
            Mythology = Mythology.Greek
        },
        new() {
            Name = "Athena",
            Description = "Athena is the goddess of handicrafts, useful arts, and battle strategy. She is the patron goddess of heroic endeavor.",
            Mythology = Mythology.Greek
        },
        new() {
            Name = "Odin",
            Description = "Odin is a god in Norse mythology, who was associated with healing, death, knowledge, sorcery, poetry, battle and the runic alphabet.",
            Mythology = Mythology.Norse
        }
    };

    public Task<List<GodDbObject>> AddOrUpdateGods(List<GodDbObject> gods)
    {
        this.gods.AddRange(gods);
        return Task.FromResult(gods);
    }

    public Task<IList<GodDbObject>> GetAllGodsAsync()
    {
        return Task.FromResult(gods as IList<GodDbObject>);
    }

    public Task<GodDbObject> GetGodAsync(GodParameter parameter)
    {
        return Task.FromResult(gods[parameter.Id]);
    }

    public Task<List<GodDbObject>> GetGodByNameAsync(GodByNameParameter parameter)
    {
        return Task.FromResult(gods.Where(god => god.Name.Contains(parameter.Name)).ToList());
    }
}