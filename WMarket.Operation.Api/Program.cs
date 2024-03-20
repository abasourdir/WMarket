using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument(o =>
{
    o.EnableJWTBearerAuth = false;
    o.MinEndpointVersion = 1;
    o.MaxEndpointVersion = 1;
    
    o.DocumentSettings = s =>
    {
        s.DocumentName = "Products operation API";
        s.Title = "Products operation API v1";
        s.Version = "v1";
    };
});

var app = builder.Build();

app.UseFastEndpoints(c =>
{
    c.Versioning.PrependToRoute = true;
    c.Endpoints.RoutePrefix = "api";
});
app.UseSwaggerGen();

app.Run();