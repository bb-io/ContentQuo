using Apps.ContentQuo.Models.Responses;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;
using System.Net.Mime;
using File = Blackbird.Applications.Sdk.Common.Files.File;

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

    [Action("List evaluations", Description = "List evaluations")]
    public async Task<ListEvaluationsResponse> ListAllEvaluations()
    {
        var request = new RestRequest("/evaluations", Method.Get);
        var response = await _client.ExecuteAsync<ListEvaluationsResponse>(request);
        return response.Data;
    }

}