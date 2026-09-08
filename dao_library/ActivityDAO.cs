namespace dao_library;

using dao_library.entity_framework;
using entity_library;

public class ActivityDAO
{
    private readonly AppDbContext _context;

    public ActivityDAO(AppDbContext context)
    {
        _context = context;
    }

    public Activity Create(Activity activity)
    {
        _context.Activities.Add(activity);
        _context.SaveChanges();
        return activity;
    }

    public Activity? ReadById(long id)
    {
        return _context.Activities.FirstOrDefault(a => a.Id == id);
    }

    public bool Update(Activity activity)
    {
        var existing = _context.Activities.FirstOrDefault(a => a.Id == activity.Id);
        if (existing == null)
        {
            return false;
        }

        existing.Title = activity.Title;
        existing.Description = activity.Description;

        _context.SaveChanges();
        return true;
    }

    public bool DeleteById(long id)
    {
        var activity = _context.Activities.FirstOrDefault(a => a.Id == id);
        if (activity == null)
        {
            return false;
        }

        _context.Activities.Remove(activity);
        _context.SaveChanges();
        return true;
    }

    public List<Activity> GetAll()
    {
        return _context.Activities.ToList();
    }
}