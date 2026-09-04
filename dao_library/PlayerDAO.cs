namespace dao_library;

using entity_library;

public class PlayerDAO
{
    private static long _autoIncrementId = 3;

    public Player Create(Player player)
    {
        player.Id = _autoIncrementId++;
        MockDatabase.Players.Add(player);
        return player;
    }

    public Player? ReadById(long id) => MockDatabase.Players.FirstOrDefault(p => p.Id == id);

    public bool Update(Player player)
    {
        var existing = ReadById(player.Id);
        if (existing == null) return false;

        existing.Name = player.Name;
        existing.Age = player.Age;
        existing.Dni = player.Dni;
        existing.Numero = player.Numero;
        return true;
    }

    public bool DeleteById(long id)
    {
        var player = ReadById(id);
        return player != null && MockDatabase.Players.Remove(player);
    }

    public List<Player> GetAll() => MockDatabase.Players;
}