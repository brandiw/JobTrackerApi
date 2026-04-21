using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace JobTrackerApi.Models.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ApplicationStatus
{
    Applied = 0,
    
    [JsonStringEnumMemberName("Initial Screen")]
    InitialScreen = 1,

    [JsonStringEnumMemberName("Code Test")]
    CodeTest = 2,
    
    Interviewing = 3,
    Closed = 4,
    Rejected = 5,
    Offer = 6
}