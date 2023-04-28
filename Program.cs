using rapidapiaspnet.Auth;
using rapidapiaspnet.RequestInfoProviders;
using Microsoft.OpenApi.Models;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
    .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ConnectionValidationSettings>(configuration.GetSection("Auth"));

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IRapidApiRequestInfoProvider, RapidApiRequestInfoProvider>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RapidAPI Asp.NET", Version = "v1" });

    var filePath = Path.Combine(System.AppContext.BaseDirectory, "rapidapiaspnet.xml");
         c.IncludeXmlComments(filePath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // Enable connection validation in a non-development environment
    app.UseMiddleware<ConnectionValidation>();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
