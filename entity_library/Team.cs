namespace entity_library;

public class Team
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public List<Player> Players { get; set; } = new();
}