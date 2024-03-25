using WMarket.Data.Repositories.Product.Models.Request;
using WMarket.Data.Repositories.Product.Models.Response;

namespace WMarket.Data.Repositories.Product.Interfaces;

public interface IProductRepository : IRepository
{
    Task<long> InsertAsync(InsertProductRepositoryRequest request);

    Task<IEnumerable<SearchProductsByNameRepositoryResponse>> SearchByNameAsync(SearchProductsByNameRepositoryRequest request);

    Task<UpdateProductRepositoryResponse> UpdateAsync(UpdateProductRepositoryRequest request);
    
    Task<long> DeleteAsync(DeleteProductRepositoryRequest request);

    Task<ProductByIdRepositoryResponse?> GetByIdAsync(ProductByIdRepositoryRequest request);

    Task<IEnumerable<ProductByIdsRepositoryResponse>> GetByIdsAsync(ProductByIdsRepositoryRequest request);
}