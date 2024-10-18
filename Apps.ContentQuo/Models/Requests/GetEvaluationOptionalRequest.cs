using Apps.ContentQuo.DataSourceHandler;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.ContentQuo.Models.Requests;

public class GetEvaluationOptionalRequest
{
    [Display("Evaluation ID"), DataSource(typeof(EvaluationDataHandler))]
    public string? Id { get; set; }
}