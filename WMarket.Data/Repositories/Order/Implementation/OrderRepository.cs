using Dapper;
using WMarket.Data.ConnectionFactories;
using WMarket.Data.Repositories.Order.Interfaces;
using WMarket.Data.Repositories.Order.Models.Request;
using WMarket.Data.Repositories.Order.Models.Response;

namespace WMarket.Data.Repositories.Order.Implementation;

public class OrderRepository : IOrderRepository
{
    private readonly SqlConnectionFactory _connectionFactory;

    public OrderRepository(SqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }
    
    public async Task<long> InsertAsync(InsertOrderRepositoryRequest request)
    {
        var connection = await _connectionFactory.OpenAsync();

        var result = await connection.ExecuteScalarAsync<long>("[dbo].[Orders_Insert]", request);

        return result;
    }

    public async Task SetStatusAsync(SetOrderStatusRepositoryRequest request)
    {
        var connection = await _connectionFactory.OpenAsync();

        await connection.ExecuteAsync("[dbo].[Orders_SetStatus]", request);
    }

    public async Task<GetOrderByIdRepositoryResponse?> GetByIdAsync(GetOrderByIdRepositoryRequest request)
    {
        var connection = await _connectionFactory.OpenAsync();

        var result = await connection.QueryFirstOrDefaultAsync<GetOrderByIdRepositoryResponse>("[dbo].[Orders_GetById]", request);

        return result;
    }
}