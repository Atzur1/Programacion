namespace dao_library;

using entity_library;

public class CourseDAO
{
    private static long _autoIncrementId = 3;

    public Course Create(Course course)
    {
        course.Id = _autoIncrementId++;
        MockDatabase.Courses.Add(course);
        return course;
    }

    public Course? ReadById(long id) => MockDatabase.Courses.FirstOrDefault(c => c.Id == id);

    public bool Update(Course course)
    {
        var existing = ReadById(course.Id);
        if (existing == null) return false;

        existing.Name = course.Name;
        return true;
    }

    public bool DeleteById(long id)
    {
        var course = ReadById(id);
        return course != null && MockDatabase.Courses.Remove(course);
    }

    public List<Course> GetAll() => MockDatabase.Courses;
}