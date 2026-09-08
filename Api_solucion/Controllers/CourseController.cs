using Microsoft.AspNetCore.Mvc;
using dao_library;
using entity_library;

namespace Api_solucion.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
    private readonly CourseDAO _courseDAO;

    public CourseController(CourseDAO courseDAO)
    {
        _courseDAO = courseDAO;
    }

    [HttpGet]
    public ActionResult<List<Course>> GetAll()
    {
        return Ok(_courseDAO.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Course> GetById(long id)
    {
        var course = _courseDAO.ReadById(id);
        if (course == null) return NotFound("Curso no encontrado.");
        return Ok(course);
    }

    [HttpPost]
    public ActionResult<Course> Create([FromBody] Course course)
    {
        var created = _courseDAO.Create(course);
        return Created($"api/course/{created.Id}", created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(long id, [FromBody] Course course)
    {
        course.Id = id;
        bool updated = _courseDAO.Update(course);
        if (!updated) return NotFound("No se encontró el curso para actualizar.");
        return Ok(course);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        bool deleted = _courseDAO.DeleteById(id);
        if (!deleted) return NotFound("No se encontró el curso para eliminar.");
        return NoContent();
    }
}