using JobTrackerApi.Contracts.Companies;
using JobTrackerApi.Data;
using JobTrackerApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobTrackerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompaniesController : ControllerBase
{
    private readonly AppDbContext _context;

    public CompaniesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/companies
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
    {
        var companies = await _context.Companies
            .AsNoTracking()
            .OrderBy(c => c.Name)
            .Select(c => new CompanyResponse
            {
                Id = c.Id,
                Name = c.Name,
                Website = c.Website,
                LocationCity = c.LocationCity,
                LocationState = c.LocationState
            })
            .ToListAsync();

        return Ok(companies);
    }

    // GET: api/companies/{id}
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Company>> GetCompany(int id)
    {
        var company = await _context.Companies
            .AsNoTracking()
            .Select(c => new CompanyResponse
            {
                Id = c.Id,
                Name = c.Name,
                Website = c.Website,
                LocationCity = c.LocationCity,
                LocationState = c.LocationState
            })
            .FirstOrDefaultAsync(c => c.Id == id);
        
        if (company == null)
        {
            return NotFound();
        }

        return Ok(company);
    }

    // POST: api/companies
    [HttpPost]
    public async Task<ActionResult<Company>> CreateCompany([FromBody] CreateCompanyRequest request)
    {
        var company = new Company
        {
            Name = request.Name,
            Website = request.Website,
            LocationCity = request.LocationCity,
            LocationState = request.LocationState
        };

        _context.Companies.Add(company);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCompany), new { id = company.Id }, company);
    }

    // PUT: api/companies/{id}
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] object company)
    {
        return Ok(new { message = $"Company with id {id} updated" });
    }

    // DELETE: api/companies/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var company = await _context.Companies.FindAsync(id);

        if (company == null)
        {
            return NotFound();
        }

        _context.Companies.Remove(company);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
