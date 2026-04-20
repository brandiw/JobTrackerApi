namespace JobTrackerApi.Contracts.InterviewNotes;

public class InterviewNoteResponse
{
    public int Id { get; set; }
    public string Note { get; set; } = "";
    public string? NextStep { get; set;}
    public int JobApplicationId { get; set; }
}