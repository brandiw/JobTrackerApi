using System.ComponentModel.DataAnnotations;

namespace JobTrackerApi.Contracts.InterviewNotes;

public class CreateInterviewNoteRequest
{
    [Required]
    public string Note { get; set; } = "";

    public string? NextStep { get; set; }
}