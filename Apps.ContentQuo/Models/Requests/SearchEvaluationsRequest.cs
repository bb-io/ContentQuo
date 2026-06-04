using Apps.ContentQuo.DataSourceHandler;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Newtonsoft.Json;

namespace Apps.ContentQuo.Models.Requests;

public class SearchEvaluationsRequest
{
    [Display("Name")]
    [JsonProperty("name")]
    public string? Name { get; set; }

    [Display("Project manager user ID")]
    [JsonProperty("pmUID")]
    public long? PmUid { get; set; }

    [Display("Source locale")]
    [DataSource(typeof(LanguageDataHandler))]
    [JsonProperty("localeSrc")]
    public string? LocaleSrc { get; set; }

    [Display("Target locale")]
    [DataSource(typeof(LanguageDataHandler))]
    [JsonProperty("localeTgt")]
    public string? LocaleTgt { get; set; }

    [Display("Status ID")]
    [JsonProperty("statusId")]
    public string? StatusId { get; set; }

    [Display("Finished after")]
    [JsonProperty("finishedAfter")]
    public DateTime? FinishedAfter { get; set; }

    [Display("Limit")]
    [JsonProperty("limit")]
    public int? Limit { get; set; }

    [Display("Offset")]
    [JsonProperty("offset")]
    public int? Offset { get; set; }

    [Display("Created after")]
    [JsonProperty("createdAfter")]
    public DateTime? CreatedAfter { get; set; }

    [Display("Modified before")]
    [JsonProperty("modifiedBefore")]
    public DateTime? ModifiedBefore { get; set; }

    [Display("Modified after")]
    [JsonProperty("modifiedAfter")]
    public DateTime? ModifiedAfter { get; set; }
}
