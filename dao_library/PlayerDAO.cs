namespace dao_library;

using dao_library.entity_framework;
using entity_library;

public class PlayerDAO
{
    private readonly AppDbContext _context;

    public PlayerDAO(AppDbContext context)
    {
        _context = context;
    }

    public Player Create(Player player)
    {
        _context.Players.Add(player);
        _context.SaveChanges();
        return player;
    }

    public Player? ReadById(long id)
    {
        return _context.Players.FirstOrDefault(p => p.Id == id);
    }

    public bool Update(Player player)
    {
        var existing = _context.Players.FirstOrDefault(p => p.Id == player.Id);
        if (existing == null)
        {
            return false;
        }

        existing.Name = player.Name;
        existing.Dni = player.Dni;

        _context.SaveChanges();
        return true;
    }

    public bool DeleteById(long id)
    {
        var player = _context.Players.FirstOrDefault(p => p.Id == id);
        if (player == null)
        {
            return false;
        }

        _context.Players.Remove(player);
        _context.SaveChanges();
        return true;
    }

    public List<Player> GetAll()
    {
        return _context.Players.ToList();
    }
}