using System.Net;

namespace rapidapiaspnet.RequestInfoProviders;

public class RapidApiRequestInfoProvider : IRapidApiRequestInfoProvider
{
    protected IHttpContextAccessor HttpContextAccessor { get; private set; }

    public RapidApiRequestInfoProvider(IHttpContextAccessor httpContextAccessor)
    {
        HttpContextAccessor = httpContextAccessor;
    }

    public IPAddress[] GetForwardedFor()
    {
        if (HttpContextAccessor.HttpContext == null)
        {
            throw new InvalidOperationException("No HttpContext");
        }

        var forwarded = HttpContextAccessor.HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
        if (forwarded == null)
        {
            return Array.Empty<IPAddress>();
        }

        return ToIpAddresses(forwarded).ToArray();
    }

    public string GetProxySecret() =>
        HttpContextAccessor.HttpContext?.Request.Headers["X-RapidAPI-Proxy-Secret"].FirstOrDefault() ?? string.Empty;

    public string GetUser() =>
        HttpContextAccessor.HttpContext?.Request.Headers["X-RapidAPI-User"].FirstOrDefault() ?? string.Empty;

    public RapidApiSubscription GetSubscription()
    {
        var subscriptionString = HttpContextAccessor.HttpContext?.Request.Headers["X-RapidAPI-Subscription"].FirstOrDefault();
        if (subscriptionString == null)
        {
            return RapidApiSubscription.Unknown;
        }

        if (!Enum.TryParse<RapidApiSubscription>(subscriptionString, true, out var subscription))
        {
            return RapidApiSubscription.Unknown;
        }

        return subscription;
    }

    public string GetApiversion() =>
        HttpContextAccessor.HttpContext?.Request.Headers["X-RapidAPI-Version"].FirstOrDefault() ?? string.Empty;

    public string GetForwardedHost() =>
        HttpContextAccessor.HttpContext?.Request.Headers["X-Forwarded-Host"].FirstOrDefault() ?? string.Empty;

    public string GetApiHost() =>
        HttpContextAccessor.HttpContext?.Request.Headers["x-rapidapi-host"].FirstOrDefault() ?? string.Empty;

    private IEnumerable<IPAddress> ToIpAddresses(string ipAddressList)
    {
        var tokens = ipAddressList.Split(',', StringSplitOptions.RemoveEmptyEntries);
        foreach(var token in tokens)
        {
            if (IPAddress.TryParse(token, out var ipAddress))
            {
                yield return ipAddress;
            }
        }
    }
}
