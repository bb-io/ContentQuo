using Apps.ContentQuo.Dtos;
using Apps.ContentQuo.Models.Requests;
using Apps.ContentQuo.Models.Responses;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using Newtonsoft.Json;
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
        var jsonBody = input.GetType()
        .GetProperties()
        .Where(p => p.GetValue(input) != null && !string.IsNullOrEmpty(p.GetValue(input)?.ToString()))
        .ToDictionary(p => p.GetCustomAttributes(typeof(JsonPropertyAttribute), true).Cast<JsonPropertyAttribute>()
        .FirstOrDefault()?.PropertyName ?? p.Name.ToLower(),p => p.GetValue(input));
        request.AddJsonBody(jsonBody);

        var response = await _client.ExecuteWithErrorHandling<CreatedEvaluationDto>(request);
        return response;
    }

    [Action("Get evaluation", Description = "Get evaluation")]
    public async Task<CompleteEvaluationResponse> GetEvaluation([ActionParameter] GetEvaluationRequest input)
    {
        var infoRequest = new RestRequest($"/evaluations/{input.Id}", Method.Get);
        var infoResponse = await _client.ExecuteWithErrorHandling<EvaluationDto>(infoRequest);

        var issuesRequest = new RestRequest($"/evaluations/{input.Id}/issues", Method.Get);
        var issuesResponse = await _client.ExecuteWithErrorHandling<ListIssuesDto>(issuesRequest);

        var metricsRequest = new RestRequest($"/evaluations/{input.Id}/metrics", Method.Get);
        var metricsResponse = await _client.ExecuteWithErrorHandling<MetricsDto>(metricsRequest);

        var filesRequest = new RestRequest($"/evaluations/{input.Id}/files", Method.Get);
        var filesResponse = await _client.ExecuteWithErrorHandling<List<BilingualFileDto>>(filesRequest);

        return new CompleteEvaluationResponse
        {
            Id = infoResponse.Id,
            Name = infoResponse.Name,
            GroupId = infoResponse.GroupID.ToString(),
            GroupName = infoResponse.GroupName,
            WorkflowId = infoResponse.WorkflowID,
            WorkflowName = infoResponse.WorkflowName,
            ProfileId = infoResponse.ProfileID,
            ProjectId = infoResponse.ProjectID.ToString(),
            SourceLocale = infoResponse.SrcLocale,
            TargetLocale = infoResponse.TgtLocale,
            Assignees = infoResponse?.Assignees,
            Issues = issuesResponse?.Issues,
            Metrics = new EvaluationMetricResponse()
            {
                Grade = metricsResponse?.Metrics.FirstOrDefault()?.Grade,
                Name = metricsResponse?.Metrics.FirstOrDefault()?.Name,
                QualityScore = metricsResponse?.Metrics.FirstOrDefault()?.QualityScore ?? 0,
            },
            BilingualFiles = filesResponse
        };
    }

    [Action("Delete evaluation", Description = "Delete evaluation")]
    public async Task DeleteEvaluation([ActionParameter] GetEvaluationRequest input)
    {
        var request = new RestRequest($"/evaluations/{input.Id}", Method.Delete);
        await _client.ExecuteWithErrorHandling(request);
    }

    [Action("Start evaluation", Description = "Start evaluation")]
    public async Task StartEvaluation([ActionParameter] GetEvaluationRequest input)
    {
        var request = new RestRequest($"/evaluations/{input.Id}/start", Method.Post);
        await _client.ExecuteWithErrorHandling(request);
    }

    [Action("Download evaluation report", Description = "Download the generated evaluation report. Defaults to an .xlsx file but can be cusotmized by ContentQuo.")]
    public async Task<DownloadFileResponse> DownloadEvaluationReport([ActionParameter] GetEvaluationRequest input, [ActionParameter] OptionalReportId reportId)
    {
        var request = new RestRequest($"/evaluations/{input.Id}/reports/{reportId.ReportId ?? "0"}", Method.Get);
        var response = await _client.ExecuteWithErrorHandling(request);
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