namespace MythApi.Common.Database.Models;

public class Alias {
    public int GodId { get; set; }
    public string Name { get; set; } = null!;
    public God God { get; set; } = null!;
}