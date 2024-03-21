using WMarket.Operation.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApiServices();

var app = builder.Build();

app.UseApiServices();
app.Run();