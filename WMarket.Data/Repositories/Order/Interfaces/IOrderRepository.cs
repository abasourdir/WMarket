using WMarket.Data.Repositories.Order.Models.Request;
using WMarket.Data.Repositories.Order.Models.Response;

namespace WMarket.Data.Repositories.Order.Interfaces;

public interface IOrderRepository : IRepository
{
    Task<long> InsertAsync(InsertOrderRepositoryRequest request);

    Task SetStatusAsync(SetOrderStatusRepositoryRequest request);

    Task<GetOrderByIdRepositoryResponse?> GetByIdAsync(GetOrderByIdRepositoryRequest request);
}