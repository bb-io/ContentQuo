using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.ContentQuo;

public class ContentQuoInvocable : BaseInvocable
{
    protected AuthenticationCredentialsProvider[] Creds => InvocationContext.AuthenticationCredentialsProviders.ToArray();
    protected ContentQuoClient Client { get; }
    
    public ContentQuoInvocable(InvocationContext invocationContext) : base(invocationContext)
    {
        Client = new(Creds);
    }
}