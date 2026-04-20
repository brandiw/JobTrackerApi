using Microsoft.AspNetCore.Mvc;

namespace JobTrackerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotesController : ControllerBase
{
    // GET: api/notes/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(new { message = $"Get note with id {id}" });
    }
}
