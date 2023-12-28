using Apps.ContentQuo.Models.Responses;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.ContentQuo.DataSourceHandler;

public class EvaluationDataHandler : BaseInvocable, IAsyncDataSourceHandler
{
    private IEnumerable<AuthenticationCredentialsProvider> Creds =>
        InvocationContext.AuthenticationCredentialsProviders;

    private readonly ContentQuoClient _client;

    public EvaluationDataHandler(InvocationContext invocationContext) : base(invocationContext)
    {
        _client = new ContentQuoClient(invocationContext.AuthenticationCredentialsProviders);
    }

    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context, CancellationToken cancellationToken)
    {
        var request = new RestRequest("/evaluations", Method.Get);
        request.AddQueryParameter("limit", 20);
        if (context.SearchString != null)
            request.AddQueryParameter("name", context.SearchString);

        var response = await _client.ExecuteAsync<ListEvaluationsResponse>(request);

        return response.Data.Evaluations.ToDictionary(x => x.Id, x => x.Name);
    }
}