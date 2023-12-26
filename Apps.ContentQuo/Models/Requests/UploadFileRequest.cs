using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.ContentQuo.Models.Requests;

public class UploadFileRequest
{
    public FileReference File { get; set; }

    [Display("Path")]
    public string? FilePath { get; set; }

    [Display("Is file reference")]
    public bool? IsRef { get; set; }
}