Dotnet template for an RapidAPI/Asp.NET application.

This package is available on NuGet: https://www.nuget.org/packages/RapidAPI.Asp.Net/ and on GitHub: https://github.com/tomwimmenhove/rapidapiaspnet

To install it directly from the command line:
```console
dotnet new install RapidAPI.Asp.Net
```

Now you can create a new RapidAPI/Asp.NET application with:
```console
dotnet new rapidapi
```

After the new project is created, set the `SecretValue` in the `Auth` section
of the `appsettings.json` file to the correct `X-RapidAPI-Proxy-Secret` found
on the RapidAPI provider page for the corresponding API under the "Security"
tab and you're good to go.

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

