using Microsoft.AspNetCore.Mvc;

namespace JobTrackerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompaniesController : ControllerBase
{
    // GET: api/companies
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(new { message = "Get all companies" });
    }

    // GET: api/companies/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(new { message = $"Get company with id {id}" });
    }

    // POST: api/companies
    [HttpPost]
    public IActionResult Create([FromBody] object company)
    {
        return CreatedAtAction(nameof(GetById), new { id = 1 }, new { message = "Company created" });
    }

    // PUT: api/companies/{id}
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] object company)
    {
        return Ok(new { message = $"Company with id {id} updated" });
    }

    // DELETE: api/companies/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return NoContent();
    }
}
