using Microsoft.AspNetCore.Mvc;
using dao_library;
using entity_library;

namespace Api_solucion.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayerController : ControllerBase
{
    private readonly PlayerDAO _playerDAO;

    public PlayerController(PlayerDAO playerDAO)
    {
        _playerDAO = playerDAO;
    }

    [HttpGet]
    public ActionResult<List<Player>> GetAll() => Ok(_playerDAO.GetAll());

    [HttpGet("{id}")]
    public ActionResult<Player> GetById(long id)
    {
        var player = _playerDAO.ReadById(id);
        if (player == null) return NotFound("Jugador no encontrado.");
        return Ok(player);
    }

    [HttpPost]
    public ActionResult<Player> Create([FromBody] Player player)
    {
        var created = _playerDAO.Create(player);
        return Created($"api/player/{created.Id}", created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(long id, [FromBody] Player player)
    {
        player.Id = id;
        bool updated = _playerDAO.Update(player);
        if (!updated) return NotFound("No se encontró el jugador para actualizar.");
        return Ok(player);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        bool deleted = _playerDAO.DeleteById(id);
        if (!deleted) return NotFound("No se encontró el jugador para eliminar.");
        return NoContent();
    }
}