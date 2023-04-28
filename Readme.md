Dotnet template for an RapidAPI Asp.NET application.

Install with:

```console
dotnet new install ./
```

Set the `SecretValue` in the `Auth` section of the `appsettings.json` file
to the correct `X-RapidAPI-Proxy-Secret` found on the RapidAPI provider page
for the corresponding API under the "Security" tab and you're good to go.

The default API implements one endpoint /Test/test that returns JSON data of the following format:
```json
{
  "forwardedFor": [
    "1.2.3.4"
  ],
  "user": "SomeRapidAPIUser",
  "proxySecret": "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
  "subscription": "Basic",
  "apiVersion": "1.2.8",
  "apiHost": "rapidapiaspnet.p.rapidapi.com"
}
```

