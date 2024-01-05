using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.ContentQuo.Dtos;

public class IssueDto
{
    [JsonProperty("categories")]
    public List<Category> Categories { get; set; }

    [JsonProperty("description")]
    public string? Description { get; set; }

    [Display("File name")]
    [JsonProperty("fileName")]
    public string FileName { get; set; }

    [Display("ID")]
    [JsonProperty("id")]
    public string Id { get; set; }

    [Display("Segment ID")]
    [JsonProperty("segmentId")]
    public string SegmentId { get; set; }

    [JsonProperty("severity")]
    public string Severity { get; set; }

    [Display("Status")]
    [JsonProperty("status")]
    public Status Status { get; set; }
}

public class Category
{
    [Display("ID")]
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }
}

public class Status
{
    [Display("ID")]
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }
}