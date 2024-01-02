using MythApi.Gods.Interfaces;

namespace MythApi.Gods.Models;

public class God : IGod {
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public Mythology Mythology { get; set; } = default!;
}
