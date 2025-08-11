using System.Globalization;
using Apps.ContentQuo.Dtos;
using Apps.ContentQuo.Models.Requests;
using Apps.ContentQuo.Models.Responses;
using Apps.ContentQuo.Polling.Models.Memory;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Polling;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using RestSharp;

namespace Apps.ContentQuo.Polling;

[PollingEventList]

public class PollingList(InvocationContext invocationContext) : BaseInvocable(invocationContext)
{
    [PollingEvent("On evaluations created", "On any new evaluations created")]
    public Task<PollingEventResponse<DateMemory, ListEvaluationsResponse>> OnEvaluationsCreated(
        PollingEventRequest<DateMemory> request,
        [PollingEventParameter] GetEvaluationOptionalRequest optionalRequest) => ProcessEvaluationPolling(request, new()
    {
        ["createdAfter"] = request.Memory?.LastInteractionDate.ToString(CultureInfo.InvariantCulture)
    }, optionalRequest);  
    
    [PollingEvent("On evaluations finished", "On any evaluations finished")]
    public Task<PollingEventResponse<DateMemory, ListEvaluationsResponse>> OnEvaluationsFinished(
        PollingEventRequest<DateMemory> request,
        [PollingEventParameter] GetEvaluationOptionalRequest optionalRequest) => ProcessEvaluationPolling(request, new()
    {
        ["finishedAfter"] = request.Memory?.LastInteractionDate.ToString(CultureInfo.InvariantCulture)
    }, optionalRequest);
    
    public async Task<PollingEventResponse<DateMemory, ListEvaluationsResponse>> ProcessEvaluationPolling(
        PollingEventRequest<DateMemory> request,
        Dictionary<string, string?> query,
        GetEvaluationOptionalRequest optionalRequest)
    {
        if (request.Memory is null)
        {
            return new()
            {
                FlyBird = false,
                Memory = new()
                {
                    LastInteractionDate = DateTime.UtcNow
                }
            };
        }

        var result = await ListEvaluations(query);

        if (!result.Any())
        {
            return new()
            {
                FlyBird = false,
                Memory = new()
                {
                    LastInteractionDate = DateTime.UtcNow
                }
            };
        }
      
        if (optionalRequest.Id != null)
        {
            result = result.Where(x => x.Id == optionalRequest.Id).ToList();
        }

        return new()
        {
            FlyBird = true,
            Result = new()
            {
                Evaluations = result
            },
            Memory = new()
            {
                LastInteractionDate = DateTime.UtcNow
            }
        };
    }

    private async Task<List<EvaluationDto>> ListEvaluations(Dictionary<string, string?> query)
    {
        var client = new ContentQuoClient(InvocationContext.AuthenticationCredentialsProviders);

        var endpoint = "/evaluations";
        var offset = 0;
        var limit = 500;

        var result = new List<EvaluationDto>();
        ListEvaluationsResponse response;
        do
        {
            var listRequest = new RestRequest(endpoint
                .SetQueryParameter("limit", limit.ToString())
                .SetQueryParameter("offset", offset.ToString()));
            
            query.ToList().ForEach(x => listRequest.AddQueryParameter(x.Key, x.Value));

            response = (await client.ExecuteWithErrorHandling<ListEvaluationsResponse>(listRequest));

            result.AddRange(response.Evaluations);
            offset += limit;
        } while (response.Evaluations.Any());

        return result;
    }
}