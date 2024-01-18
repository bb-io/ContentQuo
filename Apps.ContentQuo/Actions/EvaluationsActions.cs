using Apps.ContentQuo.Dtos;
using Apps.ContentQuo.Models.Requests;
using Apps.ContentQuo.Models.Responses;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using RestSharp;
using System.Net.Mime;

namespace Apps.ContentQuo.Actions;

[ActionList]
public class EvaluationsActions : BaseInvocable
{
    #region Fields

    private readonly ContentQuoClient _client;

    private readonly IFileManagementClient _fileManagementClient;

    #endregion

    public EvaluationsActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient) : base(invocationContext)
    {
        _client = new ContentQuoClient(invocationContext.AuthenticationCredentialsProviders);
        _fileManagementClient = fileManagementClient;
    }

    [Action("Create evaluation", Description = "Create evaluation")]
    public async Task<CreatedEvaluationDto> CreateEvaluation([ActionParameter] CreateEvaluationRequest input)
    {
        var request = new RestRequest("/evaluations", Method.Post);
        request.AddJsonBody(input);
        var response = await _client.ExecuteAsync<CreatedEvaluationDto>(request);
        return response.Data;
    }

    [Action("Get evaluation", Description = "Get evaluation")]
    public async Task<CompleteEvaluationResponse> GetEvaluation([ActionParameter] GetEvaluationRequest input)
    {
        var infoRequest = new RestRequest($"/evaluations/{input.Id}", Method.Get);
        var infoResponse = await _client.ExecuteAsync<EvaluationDto>(infoRequest);

        var issuesRequest = new RestRequest($"/evaluations/{input.Id}/issues", Method.Get);
        var issuesResponse = await _client.ExecuteAsync<ListIssuesDto>(issuesRequest);

        var metricsRequest = new RestRequest($"/evaluations/{input.Id}/metrics", Method.Get);
        var metricsResponse = await _client.ExecuteAsync<MetricsDto>(metricsRequest);

        var filesRequest = new RestRequest($"/evaluations/{input.Id}/files", Method.Get);
        var filesResponse = await _client.ExecuteAsync<List<BilingualFileDto>>(filesRequest);

        return new CompleteEvaluationResponse
        {
            Id = infoResponse.Data.Id,
            Name = infoResponse.Data.Name,
            GroupId = infoResponse.Data.GroupID,
            GroupName = infoResponse.Data.GroupName,
            WorkflowId = infoResponse.Data.WorkflowID,
            WorkflowName = infoResponse.Data.WorkflowName,
            ProfileId = infoResponse.Data.ProfileID,
            ProjectId = infoResponse.Data.ProjectID,
            SourceLocale = infoResponse.Data.SrcLocale,
            TargetLocale = infoResponse.Data.TgtLocale,
            Assignees = infoResponse?.Data?.Assignees,
            Issues = issuesResponse.Data?.Issues,
            Metrics = new EvaluationMetricResponse()
            {
                Grade = metricsResponse.Data?.Metrics.FirstOrDefault()?.Grade,
                Name = metricsResponse.Data?.Metrics.FirstOrDefault()?.Name,
                QualityScore = metricsResponse.Data?.Metrics.FirstOrDefault()?.QualityScore ?? 0,
            },
            BilingualFiles = filesResponse.Data
        };
    }

    [Action("Delete evaluation", Description = "Delete evaluation")]
    public async Task DeleteEvaluation([ActionParameter] GetEvaluationRequest input)
    {
        var request = new RestRequest($"/evaluations/{input.Id}", Method.Delete);
        await _client.ExecuteAsync(request);
    }

    [Action("Start evaluation", Description = "Start evaluation")]
    public async Task StartEvaluation([ActionParameter] GetEvaluationRequest input)
    {
        var request = new RestRequest($"/evaluations/{input.Id}/start", Method.Post);
        await _client.ExecuteAsync(request);
    }

    //[Action("Get evaluation issues", Description = "Get all the evaluation issues. Use the issues as table rows to insert the issues in a tabular app")]
    //public async Task<ListEvaluationIssuesResponse> GetEvaluationIssues([ActionParameter] GetEvaluationRequest input)
    //{
    //    var request = new RestRequest($"/evaluations/{input.Id}/issues", Method.Get);
    //    var response = await _client.ExecuteAsync<ListIssuesDto>(request);

    //    return new ListEvaluationIssuesResponse()
    //    {
    //        Issues = response.Data.Issues
    //    };
    //}

    //[Action("Get evaluation metric", Description = "Get the grade and quality score of an evaluation. In case of multiple metrics, the first configured metric is shown.")]
    //public async Task<EvaluationMetricResponse> GetEvaluationMetrics([ActionParameter] GetEvaluationRequest input)
    //{
    //    var request = new RestRequest($"/evaluations/{input.Id}/metrics", Method.Get);
    //    var response = await _client.ExecuteAsync<MetricsDto>(request);

    //    if (response.Data.Metrics == null || response.Data.Metrics.Count() < 1)
    //        throw new Exception("ContentQuo Evaluate did not respond with any metrics. Please contact ContentQuo to get your instance configured.");

    //    var usedMetric = response.Data.Metrics.First();

    //    return new EvaluationMetricResponse()
    //    {
    //        Grade = usedMetric.Grade,
    //        Name = usedMetric.Name,
    //        QualityScore = usedMetric.QualityScore,
    //    };
    //}

    [Action("Download evaluation report", Description = "Download the generated evaluation report. Defaults to an .xlsx file but can be cusotmized by ContentQuo.")]
    public async Task<DownloadFileResponse> DownloadEvaluationReport([ActionParameter] GetEvaluationRequest input, [ActionParameter] OptionalReportId reportId)
    {
        var request = new RestRequest($"/evaluations/{input.Id}/reports/{reportId.ReportId ?? "0"}", Method.Get);
        var response = await _client.ExecuteAsync(request);
        var contentDisposition =
            new ContentDisposition(response.ContentHeaders.FirstOrDefault(x => x.Name == "Content-Disposition")
                .Value.ToString());

        var file = await _fileManagementClient.UploadAsync(new MemoryStream(response.RawBytes), response.ContentType, contentDisposition.FileName);
        return new()
        {
            File = file
        };
    }   

}