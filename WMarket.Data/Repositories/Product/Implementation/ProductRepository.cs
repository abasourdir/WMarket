using System.Data;
using Dapper;
using WMarket.Data.ConnectionFactories;
using WMarket.Data.Repositories.Product.Interfaces;
using WMarket.Data.Repositories.Product.Models.Request;
using WMarket.Data.Repositories.Product.Models.Response;

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

    public async Task<List<SearchProductsByNameRepositoryResponse>> SearchByNameAsync(SearchProductsByNameRepositoryRequest request)
    {
        var connection = await _connectionFactory.OpenAsync();

        var result = await connection.QueryAsync<SearchProductsByNameRepositoryResponse>("[dbo].[Products_SearchByName]", request,
            commandType: CommandType.StoredProcedure);

        return result.ToList();
    }

    public async Task<UpdateProductRepositoryResponse?> UpdateAsync(UpdateProductRepositoryRequest request)
    {
        var connection = await _connectionFactory.OpenAsync();

        var result = await connection.QueryFirstOrDefaultAsync<UpdateProductRepositoryResponse>("[dbo].[Products_Update]", request,
            commandType: CommandType.StoredProcedure);

        return result;
    }

    public async Task<long> DeleteAsync(DeleteProductRepositoryRequest request)
    {
        var connection = await _connectionFactory.OpenAsync();

        var result = await connection.ExecuteScalarAsync<long>("[dbo].[Products_Delete]", request,
            commandType: CommandType.StoredProcedure);

        return result;
    }
}