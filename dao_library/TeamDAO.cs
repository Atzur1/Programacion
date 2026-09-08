namespace dao_library;

using dao_library.entity_framework;
using entity_library;

public class TeamDAO
{
    private readonly AppDbContext _context;

    public TeamDAO(AppDbContext context)
    {
        _context = context;
    }

    public Team Create(Team team)
    {
        _context.Teams.Add(team);
        _context.SaveChanges();
        return team;
    }

    public Team? ReadById(long id)
    {
        return _context.Teams.FirstOrDefault(t => t.Id == id);
    }

    public bool Update(Team team)
    {
        var existing = _context.Teams.FirstOrDefault(t => t.Id == team.Id);
        if (existing == null)
        {
            return false;
        }

        existing.Name = team.Name;

        _context.SaveChanges();
        return true;
    }

    public bool DeleteById(long id)
    {
        var team = _context.Teams.FirstOrDefault(t => t.Id == id);
        if (team == null)
        {
            return false;
        }

        _context.Teams.Remove(team);
        _context.SaveChanges();
        return true;
    }

    public List<Team> GetAll()
    {
        return _context.Teams.ToList();
    }
}