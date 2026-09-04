namespace dao_library;

using entity_library;

public class TrainerDAO
{
    private static long _autoIncrementId = 3;

    public Trainer Create(Trainer trainer)
    {
        trainer.Id = _autoIncrementId++;
        MockDatabase.Trainers.Add(trainer);
        return trainer;
    }

    public Trainer? ReadById(long id) => MockDatabase.Trainers.FirstOrDefault(t => t.Id == id);

    public bool Update(Trainer trainer)
    {
        var existing = ReadById(trainer.Id);
        if (existing == null) return false;

        existing.Name = trainer.Name;
        existing.Age = trainer.Age;
        existing.Dni = trainer.Dni;
        return true;
    }

    public bool DeleteById(long id)
    {
        var trainer = ReadById(id);
        return trainer != null && MockDatabase.Trainers.Remove(trainer);
    }

    public List<Trainer> GetAll() => MockDatabase.Trainers;
}