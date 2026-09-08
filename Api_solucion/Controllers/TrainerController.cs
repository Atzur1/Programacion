using Microsoft.AspNetCore.Mvc;
using dao_library;
using entity_library;

namespace Api_solucion.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TrainerController : ControllerBase
{
    private readonly TrainerDAO _trainerDAO;

    public TrainerController(TrainerDAO trainerDAO)
    {
        _trainerDAO = trainerDAO;
    }

    [HttpGet]
    public ActionResult<List<Trainer>> GetAll() => Ok(_trainerDAO.GetAll());

    [HttpGet("{id}")]
    public ActionResult<Trainer> GetById(long id)
    {
        var trainer = _trainerDAO.ReadById(id);
        if (trainer == null) return NotFound("Entrenador no encontrado.");
        return Ok(trainer);
    }

    [HttpPost]
    public ActionResult<Trainer> Create([FromBody] Trainer trainer)
    {
        var created = _trainerDAO.Create(trainer);
        return Created($"api/trainer/{created.Id}", created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(long id, [FromBody] Trainer trainer)
    {
        trainer.Id = id;
        bool updated = _trainerDAO.Update(trainer);
        if (!updated) return NotFound("No se encontró el entrenador para actualizar.");
        return Ok(trainer);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        bool deleted = _trainerDAO.DeleteById(id);
        if (!deleted) return NotFound("No se encontró el entrenador para eliminar.");
        return NoContent();
    }
}