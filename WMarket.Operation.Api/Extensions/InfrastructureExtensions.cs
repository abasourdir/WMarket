using System.Reflection;
using Mapster;
using MapsterMapper;
using WMarket.Common.Models.IOptions;
using WMarket.Data.ConnectionDecorators.Sql.Implementation;
using WMarket.Data.ConnectionDecorators.Sql.Interfaces;
using WMarket.Data.ConnectionFactories;
using WMarket.Data.ConnectionFactories.Sql.Implementation;
using WMarket.Data.ConnectionFactories.Sql.Interfaces;
using WMarket.Data.Repositories.Order.Implementation;
using WMarket.Data.Repositories.Order.Interfaces;
using WMarket.Data.Repositories.OrderItems.Implementation;
using WMarket.Data.Repositories.OrderItems.Interfaces;
using WMarket.Data.Repositories.Product.Implementation;
using WMarket.Data.Repositories.Product.Interfaces;
using WMarket.Modules.UseCases.Order.Cancel.Implementation;
using WMarket.Modules.UseCases.Order.Cancel.Interfaces;
using WMarket.Modules.UseCases.Order.Create.Implementation;
using WMarket.Modules.UseCases.Order.Create.Interfaces;
using WMarket.Modules.UseCases.Product.Add.Implementation;
using WMarket.Modules.UseCases.Product.Add.Interfaces;
using WMarket.Modules.UseCases.Product.Delete.Implementation;
using WMarket.Modules.UseCases.Product.Delete.Interfaces;
using WMarket.Modules.UseCases.Product.SearchByName.Implementation;
using WMarket.Modules.UseCases.Product.SearchByName.Interfaces;
using WMarket.Modules.UseCases.Product.Update.Implementation;
using WMarket.Modules.UseCases.Product.Update.Interfaces;

namespace WMarket.Operation.Api.Extensions;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<ConnectionStrings>(configuration.GetSection(nameof(ConnectionStrings)));
        services.Configure<EndpointLoggingOptions>(configuration.GetSection(nameof(EndpointLoggingOptions)));

        var config = new TypeAdapterConfig();
        config.Scan(Assembly.GetExecutingAssembly());
        
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        
        services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>();
        services.AddSingleton<ISqlConnectionDecorator, SqlConnectionDecorator>();

        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<IOrderItemRepository, OrderItemRepository>();

        services.AddTransient<IAddProductModule, AddProductModule>();
        services.AddTransient<ISearchProductsByNameModule, SearchProductsByNameModule>();
        services.AddTransient<IUpdateProductModule, UpdateProductModule>();
        services.AddTransient<IDeleteProductModule, DeleteProductModule>();
        services.AddTransient<ICreateOrderModule, CreateOrderModule>();
        services.AddTransient<ICancelOrderModule, CancelOrderModule>();

        return services;
    }
}