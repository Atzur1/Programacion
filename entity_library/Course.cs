namespace entity_library;

public class Course
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Student> Students { get; set; } = new();
    public List<Activity> Activities { get; set; } = new();
}