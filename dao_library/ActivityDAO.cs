namespace dao_library;

using entity_library;

public class ActivityDAO
{
    private static long _autoIncrementId = 3;

    public Activity Create(Activity activity)
    {
        activity.Id = _autoIncrementId++;
        MockDatabase.Activities.Add(activity);
        return activity;
    }

    public Activity? ReadById(long id) => MockDatabase.Activities.FirstOrDefault(a => a.Id == id);

    public bool Update(Activity activity)
    {
        var existing = ReadById(activity.Id);
        if (existing == null) return false;

        existing.Title = activity.Title;
        existing.Description = activity.Description;
        existing.Date = activity.Date;
        existing.TypeActivity = activity.TypeActivity;
        return true;
    }

    public bool DeleteById(long id)
    {
        var activity = ReadById(id);
        return activity != null && MockDatabase.Activities.Remove(activity);
    }

    public List<Activity> GetAll() => MockDatabase.Activities;
}