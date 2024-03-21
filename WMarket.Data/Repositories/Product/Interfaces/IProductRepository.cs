using WMarket.Data.Repositories.Product.Models.Request;
using WMarket.Data.Repositories.Product.Models.Response;

namespace WMarket.Data.Repositories.Product.Interfaces;

public interface IProductRepository : IRepository
{
    Task<long> InsertAsync(InsertProductRepositoryRequest request);

    Task<List<GetPagedProductsRepositoryResponse>> GetPagedAsync(GetPagedProductsRepositoryRequest request);
}