using System.Net;

namespace rapidapiaspnet.RequestInfoProviders;

public interface IRapidApiRequestInfoProvider
{
    IPAddress[] GetForwardedFor();

    string GetUser();

    string GetProxySecret();

    RapidApiSubscription GetSubscription();

    string GetApiversion();

    string GetForwardedHost();

    string GetApiHost();
}
