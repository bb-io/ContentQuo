using Apps.ContentQuo.Dtos;
using Apps.ContentQuo.Models.Responses;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Utils.RestSharp;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace Apps.ContentQuo;

public class ContentQuoClient : BlackBirdRestClient
{
    public ContentQuoClient(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders) : 
        base(new RestClientOptions { BaseUrl = new Uri($"{authenticationCredentialsProviders.FirstOrDefault(x => x.KeyName == "url").Value.TrimEnd('/').TrimEnd()}/api/v1"), ThrowOnAnyError = true })
    {
        var request = new RestRequest("/auth/authenticate", Method.Post);
        request.AddHeader("Content-Type", "application/json");
        request.AddJsonBody(new
        {
            key = authenticationCredentialsProviders.FirstOrDefault(x => x.KeyName == "publicKey").Value,
            secret = authenticationCredentialsProviders.FirstOrDefault(x => x.KeyName == "secret").Value
        });
        var response = Task.Run(() => ExecuteWithErrorHandling<TokenDto>(request)).GetAwaiter().GetResult();
        this.AddDefaultHeader("X-Auth-Token", response.Token);
    }

    protected override Exception ConfigureErrorException(RestResponse response)
    {
        if (response.Content == null)
            throw new PluginApplicationException(response.ErrorMessage);

        var errorMessage = $"Error: {response.Content} - Message: {response.Request?.Resource}";
        return new PluginApplicationException(errorMessage ?? "Server error");
    }

    public override async Task<T> ExecuteWithErrorHandling<T>(RestRequest request)
    {
        string content = (await ExecuteWithErrorHandling(request)).Content;
        T val = JsonConvert.DeserializeObject<T>(content, JsonSettings);
        if (val == null)
        {
            throw new PluginApplicationException($"Server response: {content}; Typeof {typeof(T)}");
        }

        return val;
    }

    public override async Task<RestResponse> ExecuteWithErrorHandling(RestRequest request)
    {
        RestResponse restResponse = await ExecuteAsync(request);
        if (!restResponse.IsSuccessStatusCode)
        {
            throw ConfigureErrorException(restResponse);
        }

        return restResponse;
    }
}