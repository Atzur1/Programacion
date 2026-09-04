namespace dao_library;

using entity_library;

public class StudentDAO
{
    private static readonly List<Student> _students = new List<Student>();
    private static long _autoIncrementId = 1;

    public Student CreateStudent(Student student)
    {
        student.Id = _autoIncrementId++;
        _students.Add(student);
        return student;
    }

    public Student? ReadStudentById(long id)
    {
        return _students.FirstOrDefault(s => s.Id == id);
    }

    public bool UpdateStudent(Student student)
    {
        var existing = ReadStudentById(student.Id);
        if (existing == null)
        {
            return false;
        }

        existing.Name = student.Name;
        existing.Dni = student.Dni;
        return true;
    }

    public bool DeleteStudentById(long id)
    {
        var student = ReadStudentById(id);
        if (student == null)
        {
            return false;
        }

        return _students.Remove(student);
    }

    public List<Student> GetAllStudents()
    {
        return _students;
    }
}