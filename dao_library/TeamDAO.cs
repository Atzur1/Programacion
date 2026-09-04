namespace dao_library;

using entity_library;

public class TeamDAO
{
    private static long _autoIncrementId = 3;

    public Team Create(Team team)
    {
        team.Id = _autoIncrementId++;
        MockDatabase.Teams.Add(team);
        return team;
    }

    public Team? ReadById(long id) => MockDatabase.Teams.FirstOrDefault(t => t.Id == id);

    public bool Update(Team team)
    {
        var existing = ReadById(team.Id);
        if (existing == null) return false;

        existing.Name = team.Name;
        existing.Category = team.Category;
        return true;
    }

    public bool DeleteById(long id)
    {
        var team = ReadById(id);
        return team != null && MockDatabase.Teams.Remove(team);
    }

    public List<Team> GetAll() => MockDatabase.Teams;
}