using Apps.ContentQuo.Dtos;

namespace Apps.ContentQuo.Models.Responses;

public class ListEvaluationIssuesResponse
{
    public List<IssueDto> Issues { get; set; }
}