using Apps.ContentQuo.Models.Responses;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.ContentQuo.DataSourceHandler;

public class EvaluationDataHandler(InvocationContext invocationContext) : ContentQuoInvocable(invocationContext), IAsyncDataSourceHandler
{
    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context, CancellationToken cancellationToken)
    {
        var request = new RestRequest("/evaluations", Method.Get);
        request.AddQueryParameter("limit", 20);
        if (context.SearchString != null)
            request.AddQueryParameter("name", context.SearchString);

        var response = await Client.ExecuteWithErrorHandling<ListEvaluationsResponse>(request);

        return response.Evaluations.ToDictionary(x => x.Id, x => x.Name);
    }
}