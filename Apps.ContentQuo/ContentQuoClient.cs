using Apps.ContentQuo.Dtos;
using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace Apps.ContentQuo;

public class ContentQuoClient : RestClient
{
    public ContentQuoClient(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders) : 
        base(new RestClientOptions { BaseUrl = new Uri("https://apac1.contentquo.com/api/v1"), ThrowOnAnyError = true }, configureSerialization: s => s.UseNewtonsoftJson())
    {
        var request = new RestRequest("/auth/authenticate", Method.Post);
        request.AddHeader("Content-Type", "application/json");
        request.AddJsonBody(new
        {
            key = authenticationCredentialsProviders.FirstOrDefault(x => x.KeyName == "publicKey").Value,
            secret = authenticationCredentialsProviders.FirstOrDefault(x => x.KeyName == "secret").Value
        });
        var response = this.Execute<TokenDto>(request).Data;
        this.AddDefaultHeader("X-Auth-Token", response.Token);
    }
}