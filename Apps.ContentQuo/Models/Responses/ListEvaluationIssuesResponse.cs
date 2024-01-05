using Apps.ContentQuo.Dtos;
using Blackbird.Applications.Sdk.Common;

namespace Apps.ContentQuo.Models.Responses;

public class ListEvaluationIssuesResponse
{
    public List<IssueDto> Issues { get; set; }

    [Display("Issues as table rows")]
    public List<RowResponse> IssuesAsTableRows { get; set; }

}

public class RowResponse
{
    public List<string> Row { get; set; }
}