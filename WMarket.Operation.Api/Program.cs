using WMarket.Operation.Api.Extensions;
using WMarket.Operation.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("serilog.json");

builder.AddLogging();
builder.Services.AddApiServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<RequestResponseLoggingMiddleware>();
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseApiServices();
app.Run();