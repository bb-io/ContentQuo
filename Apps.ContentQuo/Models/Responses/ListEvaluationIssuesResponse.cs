using Apps.ContentQuo.Dtos;
using Blackbird.Applications.Sdk.Common;

namespace Apps.ContentQuo.Models.Responses;

public class ListEvaluationIssuesResponse
{
    public List<IssueDto> Issues { get; set; }

}
