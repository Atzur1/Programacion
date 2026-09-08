namespace dao_library;

using dao_library.entity_framework;
using entity_library;

public class TrainerDAO
{
    private readonly AppDbContext _context;

    public TrainerDAO(AppDbContext context)
    {
        _context = context;
    }

    public Trainer Create(Trainer trainer)
    {
        _context.Trainers.Add(trainer);
        _context.SaveChanges();
        return trainer;
    }

    public Trainer? ReadById(long id)
    {
        return _context.Trainers.FirstOrDefault(t => t.Id == id);
    }

    public bool Update(Trainer trainer)
    {
        var existing = _context.Trainers.FirstOrDefault(t => t.Id == trainer.Id);
        if (existing == null)
        {
            return false;
        }

        existing.Name = trainer.Name;
        existing.Dni = trainer.Dni;

        _context.SaveChanges();
        return true;
    }

    public bool DeleteById(long id)
    {
        var trainer = _context.Trainers.FirstOrDefault(t => t.Id == id);
        if (trainer == null)
        {
            return false;
        }

        _context.Trainers.Remove(trainer);
        _context.SaveChanges();
        return true;
    }

    public List<Trainer> GetAll()
    {
        return _context.Trainers.ToList();
    }
}