using JobTrackerApi.Contracts.InterviewNotes;
using JobTrackerApi.Models.Enums;

namespace JobTrackerApi.Contracts.Applications;

public class JobApplicationDetailResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string? Url { get; set; }
    public ApplicationStatus Status { get; set; }
    public RoleType RoleType { get; set; }
    public int CompanyId { get; set; }
    public List<InterviewNoteResponse> Notes { get; set; } = new();
}