using WMarket.Operation.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApiServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

app.UseApiServices();
app.Run();