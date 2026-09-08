namespace dao_library;

using dao_library.entity_framework;
using entity_library;

public class CourseDAO
{
    private readonly AppDbContext _context;

    public CourseDAO(AppDbContext context)
    {
        _context = context;
    }

    public Course Create(Course course)
    {
        _context.Courses.Add(course);
        _context.SaveChanges();
        return course;
    }

    public Course? ReadById(long id)
    {
        return _context.Courses.FirstOrDefault(c => c.Id == id);
    }

    public bool Update(Course course)
    {
        var existing = _context.Courses.FirstOrDefault(c => c.Id == course.Id);
        if (existing == null)
        {
            return false;
        }

        existing.Title = course.Title;
        existing.Description = course.Description;

        _context.SaveChanges();
        return true;
    }

    public bool DeleteById(long id)
    {
        var course = _context.Courses.FirstOrDefault(c => c.Id == id);
        if (course == null)
        {
            return false;
        }

        _context.Courses.Remove(course);
        _context.SaveChanges();
        return true;
    }

    public List<Course> GetAll()
    {
        return _context.Courses.ToList();
    }
}