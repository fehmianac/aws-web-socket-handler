using Amazon.Lambda.APIGatewayEvents;
using Amazon.Runtime.Internal;

namespace Adapter.Extensions;

public static class RequestContextExtensions
{
    public static string? GetUserId(this APIGatewayProxyRequest.ProxyRequestContext context)
    {

        if (context.Authorizer == null)
            return null;

        return context.Authorizer.TryGetValue("userId", out var value) ? value?.ToString() : context.Authorizer["userId"]?.ToString();
    }
}