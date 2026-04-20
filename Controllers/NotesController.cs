using JobTrackerApi.Contracts.InterviewNotes;
using JobTrackerApi.Data;
using JobTrackerApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobTrackerApi.Controllers;

[ApiController]
[Route("api/applications/{applicationId:int}/notes")]
public class NotesController : ControllerBase
{
    private readonly AppDbContext _context;

    public NotesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<InterviewNoteResponse>> CreateInterviewNote(int applicationId, [FromBody] CreateInterviewNoteRequest request)
    {
        var applicationExists = await _context.Applications
            .AnyAsync(a => a.Id == applicationId);

        if (!applicationExists)
        {
            return NotFound();
        }

        var note = new InterviewNote
        {
            Note = request.Note,
            NextStep = request.NextStep,
            JobApplicationId = applicationId
        };

        _context.InterviewNotes.Add(note);
        await _context.SaveChangesAsync();

        var response = new InterviewNoteResponse
        {
            Id = note.Id,
            Note = note.Note,
            NextStep = note.NextStep,
            JobApplicationId = note.JobApplicationId
        };

        return CreatedAtAction(
            actionName: "GetApplication",
            controllerName: "Applications",
            routeValues: new { id = applicationId },
            value: response);
    }

    [HttpDelete("{noteId:int}")]
    public async Task<IActionResult> DeleteInterviewNote(int applicationId, int noteId)
    {
        var note = await _context.InterviewNotes.FirstOrDefaultAsync(n => n.Id == noteId && n.JobApplicationId == applicationId);

        if (note == null)
        {
            return NotFound();
        }

        _context.InterviewNotes.Remove(note);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

