using Microsoft.AspNetCore.Mvc;
using dao_library;
using entity_library;

namespace Api_solucion.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly StudentDAO _studentDAO;

    public StudentController(StudentDAO studentDAO)
    {
        _studentDAO = studentDAO;
    }

    [HttpGet]
    public ActionResult<List<Student>> GetAll()
    {
        return Ok(_studentDAO.GetAllStudents());
    }

    [HttpGet("{id}")]
    public ActionResult<Student> GetById(long id)
    {
        var student = _studentDAO.ReadStudentById(id);
        if (student == null) 
        {
            return NotFound("Estudiante no encontrado.");
        }
        return Ok(student);
    }

[HttpPost]
    public ActionResult<Student> Create([FromBody] Student student)
{
    var existingStudent = _studentDAO.ReadByDni(student.Dni);
    if (existingStudent != null)
    {
        return BadRequest("Ya existe un estudiante registrado con ese DNI.");
    }

    var created = _studentDAO.CreateStudent(student);
    return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
}

    [HttpPut("{id}")]
    public IActionResult Update(long id, [FromBody] Student student)
    {
        student.Id = id;
        bool updated = _studentDAO.UpdateStudent(student);
        if (!updated) 
        {
            return NotFound("No se encontró el estudiante para actualizar.");
        }
        return Ok(student);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        bool deleted = _studentDAO.DeleteStudentById(id);
        if (!deleted) 
        {
            return NotFound("No se encontró el estudiante para eliminar.");
        }
        return NoContent();
    }
}