namespace dao_library;

using dao_library.entity_framework;
using entity_library;

public class StudentDAO
{
    private readonly AppDbContext _context;

    public StudentDAO(AppDbContext context)
    {
        _context = context;
    }

    public Student CreateStudent(Student student)
    {
        _context.Students.Add(student);
        _context.SaveChanges();
        return student;
    }

    public Student? ReadStudentById(long id)
    {
        return _context.Students.FirstOrDefault(s => s.Id == id);
    }

    // Método para validar duplicados por DNI
    public Student? ReadByDni(string dni)
    {
        return _context.Students.FirstOrDefault(s => s.Dni == dni);
    }

    public bool UpdateStudent(Student student)
    {
        var existing = _context.Students.FirstOrDefault(s => s.Id == student.Id);
        if (existing == null)
        {
            return false;
        }

        existing.Name = student.Name;
        existing.Dni = student.Dni;

        _context.SaveChanges();
        return true;
    }

    public bool DeleteStudentById(long id)
    {
        var student = _context.Students.FirstOrDefault(s => s.Id == id);
        if (student == null)
        {
            return false;
        }

        _context.Students.Remove(student);
        _context.SaveChanges();
        return true;
    }

    public List<Student> GetAllStudents()
    {
        return _context.Students.ToList();
    }
}