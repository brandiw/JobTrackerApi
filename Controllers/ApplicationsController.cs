using Microsoft.AspNetCore.Mvc;

namespace JobTrackerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApplicationsController : ControllerBase
{
    // GET: api/applications
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(new { message = "Get all applications" });
    }

    // GET: api/applications/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(new { message = $"Get application with id {id}" });
    }

    // POST: api/applications
    [HttpPost]
    public IActionResult Create([FromBody] object application)
    {
        return CreatedAtAction(nameof(GetById), new { id = 1 }, new { message = "Application created" });
    }

    // PUT: api/applications/{id}
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] object application)
    {
        return Ok(new { message = $"Application with id {id} updated" });
    }

    // DELETE: api/applications/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return NoContent();
    }
}
