using Microsoft.AspNetCore.Mvc;
using rapidapiaspnet.RequestInfoProviders;

namespace rapidapiaspnet.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly IRapidApiRequestInfoProvider _requestInfoProvider;

    public TestController(IRapidApiRequestInfoProvider requestInfoProvider)
    {
        _requestInfoProvider = requestInfoProvider;
    }

    /// <summary>
    /// Demonstration endpoint.
    /// </summary>
    [HttpGet("test")]
    public IActionResult Test() => Ok(new
    {
        ForwardedFor = _requestInfoProvider.GetForwardedFor(),
        User = _requestInfoProvider.GetUser(),
        ProxySecret = _requestInfoProvider.GetProxySecret(),
        Subscription = _requestInfoProvider.GetSubscription().ToString(),
        ApiVersion = _requestInfoProvider.GetApiversion(),
        ApiHost = _requestInfoProvider.GetApiHost(),
    });
}
