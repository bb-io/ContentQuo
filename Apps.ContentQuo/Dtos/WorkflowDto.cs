using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.ContentQuo.Dtos;

public class WorkflowDto
{
    [Display("Current step")]
    [JsonProperty("currentStep")]
    public Step CurrentStep { get; set; }

    [Display("ID")]
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [Display("PM deadline")]
    [JsonProperty("pm_deadline")]
    public DateTime PmDeadline { get; set; }

    [JsonProperty("steps")]
    public List<Step> Steps { get; set; }
}

public class AssignedUser
{
    [Display("Assignee index")]
    [JsonProperty("assigneeIndex")]
    public int AssigneeIndex { get; set; }

    [Display("User ID")]
    [JsonProperty("userId")]
    public int UserId { get; set; }
}

public class Step
{
    [Display("Assigned users")]
    [JsonProperty("assignedUsers")]
    public List<AssignedUser> AssignedUsers { get; set; }

    [JsonProperty("deadline")]
    public DateTime Deadline { get; set; }

    [Display("ID")]
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("instructions")]
    public string Instructions { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("order")]
    public int Order { get; set; }
}