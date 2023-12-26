using Apps.ContentQuo.Dtos;
using Apps.ContentQuo.Models.Requests;
using Apps.ContentQuo.Models.Responses;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.ContentQuo.Actions;

[ActionList]
public class EvaluationsActions : BaseInvocable
{
    #region Fields

    private readonly ContentQuoClient _client;

    #endregion

    public EvaluationsActions(InvocationContext invocationContext) : base(invocationContext)
    {
        _client = new ContentQuoClient(invocationContext.AuthenticationCredentialsProviders);
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
    public async Task<EvaluationDto> GetEvaluation([ActionParameter] GetEvaluationRequest input)
    {
        var request = new RestRequest($"/evaluations/{input.Id}", Method.Get);
        var response = await _client.ExecuteAsync<EvaluationDto>(request);
        return response.Data;
    }

    [Action("Delete evaluation", Description = "Delete evaluation")]
    public async Task DeleteEvaluation([ActionParameter] GetEvaluationRequest input)
    {
        var request = new RestRequest($"/evaluations/{input.Id}", Method.Delete);
        var response = await _client.ExecuteAsync<EvaluationDto>(request);
    }

    [Action("Start evaluation", Description = "Start evaluation")]
    public async Task StartEvaluation([ActionParameter] GetEvaluationRequest input)
    {
        var request = new RestRequest($"/evaluations/{input.Id}/start", Method.Post);
        await _client.ExecuteAsync(request);
    }

    [Action("Get evaluation issues", Description = "Get evaluation issues")]
    public async Task<ListEvaluationIssuesResponse> GetEvaluationIssues([ActionParameter] GetEvaluationRequest input)
    {
        var request = new RestRequest($"/evaluations/{input.Id}/issues", Method.Get);
        var response = await _client.ExecuteAsync<List<IssueDto>>(request);
        return new ListEvaluationIssuesResponse()
        {
            Issues = response.Data
        };
    }

    // Waiting for discussion on how to use these segments in Blackbird

    //[Action("Get evaluation segments", Description = "Get evaluation segments")]
    //public async Task<ListEvaluationSegmentsResponse> GetEvaluationSegments([ActionParameter] GetEvaluationRequest input)
    //{
    //    var request = new RestRequest($"/evaluations/{input.Id}/segments", Method.Get);
    //    var response = await _client.ExecuteAsync<List<SegmentDto>>(request);
    //    return new ListEvaluationSegmentsResponse()
    //    {
    //        Segments = response.Data
    //    };
    //}

    [Action("Get evaluation workflow", Description = "Get evaluation workflow")]
    public async Task<WorkflowDto> GetEvaluationWorkflow([ActionParameter] GetEvaluationRequest input)
    {
        var request = new RestRequest($"/evaluations/{input.Id}/workflow", Method.Get);
        var response = await _client.ExecuteAsync<WorkflowDto>(request);
        return response.Data;
    }

    // Implement metrics after discussion on how to use this step in Blackbird. Main question: Are metric types variable?

    // Waiting for discussion on how to use this step in Blackbird

    //[Action("Assign user to workflow step", Description = "Assigns a user to a workflow step in an evaluation")]
    //public async Task AssignWorkflowStep([ActionParameter] GetEvaluationRequest input, 
    //    [ActionParameter] AssignWorkflowStepRequest inputStep)
    //{
    //    var request = new RestRequest($"/evaluations/{input.Id}/workflow/assign", Method.Get);
    //    request.AddQueryParameter("stepId", inputStep.StepId);
    //    request.AddQueryParameter("userId", inputStep.UserId);
    //    await _client.ExecuteAsync<WorkflowDto>(request);
    //}

}