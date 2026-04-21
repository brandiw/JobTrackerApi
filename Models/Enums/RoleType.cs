using System.Text.Json.Serialization;
namespace JobTrackerApi.Models.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RoleType
{
    Remote = 0,
    Hybrid = 1,
    Onsite = 2
}