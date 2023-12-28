using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.ContentQuo.Dtos;

public class BilingualFileDto
{
    [Display("Segment count")]
    [JsonProperty("countSegments")]
    public int CountSegments { get; set; }

    [Display("Word count")]
    [JsonProperty("countWords")]
    public int CountWords { get; set; }

    [JsonProperty("date")]
    public DateTime Date { get; set; }

    [Display("File ID")]
    [JsonProperty("fid")]
    public string Fid { get; set; }

    [Display("File URI")]
    [JsonProperty("fileUri")]
    public string FileUri { get; set; }

    [JsonProperty("size")]
    public int Size { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }
}