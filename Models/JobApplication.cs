using JobTrackerApi.Models.Enums;

namespace JobTrackerApi.Models;

public class JobApplication {
    public int Id { get; set; }
    public int CompanyId {get; set; }
    public string Title { get; set; } = "";
    public ApplicationStatus Status {get; set; } = ApplicationStatus.Applied;
    public RoleType RoleType { get; set; } = RoleType.Remote;
    public DateTime DateApplied { get; set; }

    public Company? Company { get; set; }
    public List<InterviewNote> InterviewNotes { get; set; } = new();
}