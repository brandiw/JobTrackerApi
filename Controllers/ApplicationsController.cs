using JobTrackerApi.Contracts.Applications;
using JobTrackerApi.Contracts.InterviewNotes;
using JobTrackerApi.Data;
using JobTrackerApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobTrackerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApplicationsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ApplicationsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/applications
    [HttpGet]
    public async Task<ActionResult<IEnumerable<JobApplicationResponse>>> GetApplications()
    {
        var applications = await _context.Applications
            .AsNoTracking()
            .OrderBy(a => a.Id)
            .Select(a => new JobApplicationResponse
            {
                Id = a.Id,
                Title = a.Title,
                Url = a.Url,
                Status = a.Status,
                RoleType = a.RoleType,
                CompanyId = a.CompanyId
            })
            .ToListAsync();

        return Ok(applications);
    }

    // GET: api/applications/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<JobApplicationResponse>> GetApplication(int id)
    {
        var application = await _context.Applications
            .AsNoTracking()
            .Where(a => a.Id == id)
            .Select(a => new JobApplicationDetailResponse
            {
                Id = a.Id,
                Title = a.Title,
                Url = a.Url,
                Status = a.Status,
                RoleType = a.RoleType,
                CompanyId = a.CompanyId,
                DateApplied = a.DateApplied,
                Notes = a.InterviewNotes
                    .OrderBy(n => n.Id)
                    .Select(n => new InterviewNoteResponse
                    {
                        Id = n.Id,
                        Note = n.Note,
                        NextStep = n.NextStep,
                        JobApplicationId = n.JobApplicationId
                    })
                    .ToList()
            })
            .FirstOrDefaultAsync();

        if (application == null)
        {
            return NotFound();
        }

        return Ok(application);
    }

    // POST: api/applications
    [HttpPost]
    public async Task<ActionResult<JobApplicationResponse>> CreateApplication([FromBody] CreateJobApplicationRequest request)
    {
        var companyExists = await _context.Companies.AnyAsync(c => c.Id == request.CompanyId);

        if (!companyExists)
        {
            return BadRequest($"Company with id {request.CompanyId} does not exist.");
        }

        var application = new JobApplication
        {
            Title = request.Title,
            Url = request.Url,
            Status = request.Status,
            RoleType = request.RoleType,
            DateApplied = DateTime.SpecifyKind(request.DateApplied, DateTimeKind.Utc),
            CompanyId = request.CompanyId
        };

        _context.Applications.Add(application);
        await _context.SaveChangesAsync();

        var response = new JobApplicationResponse
        {
            Id = application.Id,
            Title = application.Title,
            Url = application.Url,
            Status = application.Status,
            RoleType = application.RoleType,
            DateApplied = application.DateApplied,
            CompanyId = application.CompanyId
        };

        return CreatedAtAction(nameof(GetApplication), new { id = application.Id }, response);
    }

    // PUT: api/applications/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateApplication(int id, [FromBody] object application)
    {
        return Ok(new { message = $"Application with id {id} updated" });
    }

    // DELETE: api/applications/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteApplication(int id)
    {
        var application = await _context.Applications.FindAsync(id);

        if (application == null)
        {
            return NotFound();
        }

        _context.Applications.Remove(application);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
