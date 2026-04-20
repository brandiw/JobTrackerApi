namespace JobTrackerApi.Contracts.Companies;

public class CreateCompanyRequest
{
    public string Name { get; set; } = "";
    public string? Website { get; set; }
    public string? LocationCity { get; set; }
    public string? LocationState { get; set; }
}