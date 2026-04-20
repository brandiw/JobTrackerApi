using JobTrackerApi.Contracts.Applications;

namespace JobTrackerApi.Contracts.Companies;

public class CompanyWithApplicationsResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string? Website { get; set; }
    public string? LocationCity { get; set; }
    public string? LocationState { get; set; }
    public List<JobApplicationResponse> Applications { get; set; } = new();
}