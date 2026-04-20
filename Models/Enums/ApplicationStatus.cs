namespace JobTrackerApi.Models.Enums;

public enum ApplicationStatus
{
    Applied = 0,
    
    [Display(Name = "Initial Screen")]
    InitialScreen = 1,

    [Display(Name = "Code Test")]
    CodeTest = 2,
    
    Interviewing = 3,
    Closed = 4,
    Rejected = 5,
    Offer = 6
}