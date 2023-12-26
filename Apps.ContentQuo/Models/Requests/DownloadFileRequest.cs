using Blackbird.Applications.Sdk.Common;

namespace Apps.ContentQuo.Models.Requests;

public class DownloadFileRequest
{
    [Display("File ID")]
    public string Id { get; set; }
}