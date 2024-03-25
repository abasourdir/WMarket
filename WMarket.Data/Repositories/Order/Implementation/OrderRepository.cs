using WMarket.Data.ConnectionDecorators.Sql.Interfaces;
using WMarket.Data.Repositories.Order.Interfaces;
using WMarket.Data.Repositories.Order.Models.Request;
using WMarket.Data.Repositories.Order.Models.Response;

namespace WMarket.Data.Repositories.Order.Implementation;

public class OrderRepository : IOrderRepository
{
    private readonly ISqlConnectionDecorator _connectionDecorator;

    public OrderRepository(ISqlConnectionDecorator connectionDecorator)
    {
        _connectionDecorator = connectionDecorator;
    }
    
    public Task<long> InsertAsync(InsertOrderRepositoryRequest request)
        => _connectionDecorator.ExecuteScalarAsync<long>("[dbo].[Orders_Insert]", request);

    public Task SetStatusAsync(SetOrderStatusRepositoryRequest request)
        => _connectionDecorator.ExecuteAsync("[dbo].[Orders_SetStatus]", request);

    public Task<GetOrderByIdRepositoryResponse?> GetByIdAsync(GetOrderByIdRepositoryRequest request)
        => _connectionDecorator.QueryFirstOrDefaultAsync<GetOrderByIdRepositoryResponse>("[dbo].[Orders_GetById]", request);
}