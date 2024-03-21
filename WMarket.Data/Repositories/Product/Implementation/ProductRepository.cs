using System.Data;
using Dapper;
using WMarket.Data.ConnectionFactories;
using WMarket.Data.Repositories.Product.Interfaces;
using WMarket.Data.Repositories.Product.Models.Request;

namespace WMarket.Data.Repositories.Product.Implementation;

public class ProductRepository : IProductRepository
{
    private readonly SqlConnectionFactory _connectionFactory;

    public ProductRepository(SqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }
    
    public async Task<long> InsertAsync(InsertProductRepositoryRequest request)
    {
        var connection = await _connectionFactory.OpenAsync();

        var result = await connection.ExecuteScalarAsync<long>("[dbo].[Products_Insert]", request,
            commandType: CommandType.StoredProcedure);

        return result;
    }
}