using WMarket.Operation.Api.Extensions;
using WMarket.Operation.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApiServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddTransient<ErrorHandlingMiddleware>();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseApiServices();
app.Run();