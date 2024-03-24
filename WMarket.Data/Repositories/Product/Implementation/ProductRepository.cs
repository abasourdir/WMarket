using WMarket.Data.ConnectionDecorators.Sql.Interfaces;
using WMarket.Data.Repositories.Product.Interfaces;
using WMarket.Data.Repositories.Product.Models.Request;
using WMarket.Data.Repositories.Product.Models.Response;

namespace WMarket.Data.Repositories.Product.Implementation;

public class ProductRepository : IProductRepository
{
    private readonly ISqlConnectionDecorator _connectionDecorator;

    public ProductRepository(ISqlConnectionDecorator connectionDecorator)
    {
        _connectionDecorator = connectionDecorator;
    }
    
    public async Task<long> InsertAsync(InsertProductRepositoryRequest request)
    {
        var result = await _connectionDecorator.ExecuteScalarAsync<long>("[dbo].[Products_Insert]", request);

        return result;
    }

    public async Task<List<SearchProductsByNameRepositoryResponse>> SearchByNameAsync(SearchProductsByNameRepositoryRequest request)
    {
        var result = await _connectionDecorator.QueryAsync<SearchProductsByNameRepositoryResponse>("[dbo].[Products_SearchByName]", request);

        return result.ToList();
    }

    public async Task<UpdateProductRepositoryResponse?> UpdateAsync(UpdateProductRepositoryRequest request)
    {
        var result = await _connectionDecorator.QueryFirstOrDefaultAsync<UpdateProductRepositoryResponse>("[dbo].[Products_Update]", request);

        return result;
    }

    public async Task<long> DeleteAsync(DeleteProductRepositoryRequest request)
    {
        var result = await _connectionDecorator.ExecuteScalarAsync<long>("[dbo].[Products_Delete]", request);

        return result;
    }

    public async Task<ProductByIdRepositoryResponse?> GetByIdAsync(ProductByIdRepositoryRequest request)
    {
        var result = await _connectionDecorator.QueryFirstOrDefaultAsync<ProductByIdRepositoryResponse>("[dbo].[Products_GetById]", request);

        return result;
    }
}