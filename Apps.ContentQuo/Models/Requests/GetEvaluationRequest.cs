using Apps.ContentQuo.DataSourceHandler;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.ContentQuo.Models.Requests;

public class GetEvaluationRequest
{
    [Display("Evaluation")]
    [DataSource(typeof(EvaluationDataHandler))]
    public string Id { get; set; }
}