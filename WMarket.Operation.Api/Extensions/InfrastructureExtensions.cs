using System.Reflection;
using Mapster;
using MapsterMapper;
using WMarket.Common.Models.IOptions;
using WMarket.Data.ConnectionFactories;
using WMarket.Data.Repositories.Product.Implementation;
using WMarket.Data.Repositories.Product.Interfaces;
using WMarket.Modules.UseCases.Product.Add.Implementation;
using WMarket.Modules.UseCases.Product.Add.Interfaces;
using WMarket.Modules.UseCases.Product.Get.Implementation;
using WMarket.Modules.UseCases.Product.Get.Interfaces;
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

        var config = new TypeAdapterConfig();
        config.Scan(Assembly.GetExecutingAssembly());
        
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        
        services.AddSingleton<SqlConnectionFactory>();

        services.AddTransient<IProductRepository, ProductRepository>();

        services.AddTransient<IAddProductModule, AddProductModule>();
        services.AddTransient<IGetProductsModule, GetProductsModule>();
        services.AddTransient<IUpdateProductModule, UpdateProductModule>();

        return services;
    }
}