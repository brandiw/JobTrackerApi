namespace JobTrackerApi.Models;

public class InterviewNote
{
    public int Id { get; set; }
    public int JobApplicationId { get; set; }
    public string Note { get; set; } = "";
    public string? NextStep { get; set; }

    public JobApplication? JobApplication { get; set; }
}