using System.ComponentModel.DataAnnotations;
using JobTrackerApi.Models.Enums;

namespace JobTrackerApi.Contracts.Applications;

public class CreateJobApplicationRequest
{
    [Required]
    [StringLength(150)]
    public string Title { get; set; } = "";

    [StringLength(500)]
    [Url]
    public string? Url { get; set; }

    [Required]
    public ApplicationStatus Status { get; set; }

    [Required]
    public RoleType RoleType { get; set; }

    [Required]
    public DateTime DateApplied { get; set; }

    [Required]
    public int CompanyId { get; set; }
}