using Microsoft.AspNetCore.Mvc;
using dao_library;
using entity_library;

namespace Api_solucion.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeamController : ControllerBase
{
    private readonly TeamDAO _teamDAO;

    public TeamController(TeamDAO teamDAO)
    {
        _teamDAO = teamDAO;
    }

    [HttpGet]
    public ActionResult<List<Team>> GetAll() => Ok(_teamDAO.GetAll());

    [HttpGet("{id}")]
    public ActionResult<Team> GetById(long id)
    {
        var team = _teamDAO.ReadById(id);
        if (team == null) return NotFound("Equipo no encontrado.");
        return Ok(team);
    }

    [HttpPost]
    public ActionResult<Team> Create([FromBody] Team team)
    {
        var created = _teamDAO.Create(team);
        return Created($"api/team/{created.Id}", created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(long id, [FromBody] Team team)
    {
        team.Id = id;
        bool updated = _teamDAO.Update(team);
        if (!updated) return NotFound("No se encontró el equipo para actualizar.");
        return Ok(team);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        bool deleted = _teamDAO.DeleteById(id);
        if (!deleted) return NotFound("No se encontró el equipo para eliminar.");
        return NoContent();
    }
}