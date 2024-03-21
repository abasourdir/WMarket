using WMarket.Data.Repositories.Product.Models.Request;

namespace WMarket.Data.Repositories.Product.Interfaces;

public interface IProductRepository : IRepository
{
    Task<long> InsertAsync(InsertProductRepositoryRequest request);
}