namespace JobTrackerApi.Models;

public class Company {
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string? Website { get; set; }
    public string? LocationCity { get; set; }
    public string? LocationState { get; set; }

    public List<JobApplication> Applications {get; set; } = new();
}