using Apps.ContentQuo.Dtos;

namespace Apps.ContentQuo.Models.Responses;

public class ListEvaluationsResponse
{
    public List<EvaluationDto> Evaluations { get; set; }
}