namespace Api_solucion.Controllers;

using Microsoft.AspNetCore.Mvc;
using dao_library;
using entity_library;

[ApiController]
[Route("api/[controller]")]
public class ActivityController : ControllerBase
{
    private readonly ActivityDAO _activityDAO;

    public ActivityController(ActivityDAO activityDAO)
    {
        _activityDAO = activityDAO;
    }

    [HttpGet]
    public ActionResult<List<Activity>> GetAll()
    {
        return Ok(_activityDAO.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Activity> GetById(long id)
    {
        var activity = _activityDAO.ReadById(id);
        if (activity == null)
        {
            return NotFound();
        }
        return Ok(activity);
    }

    [HttpPost]
    public ActionResult<Activity> Create([FromBody] Activity activity)
    {
        var created = _activityDAO.Create(activity);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(long id, [FromBody] Activity activity)
    {
        activity.Id = id;
        var updated = _activityDAO.Update(activity);
        if (!updated)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        var deleted = _activityDAO.DeleteById(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}