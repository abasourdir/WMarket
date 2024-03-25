using System.Data;
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
    
    public Task<long> InsertAsync(InsertProductRepositoryRequest request)
        => _connectionDecorator.ExecuteScalarAsync<long>("[dbo].[Products_Insert]", request);

    public Task<IEnumerable<SearchProductsByNameRepositoryResponse>> SearchByNameAsync(SearchProductsByNameRepositoryRequest request)
        => _connectionDecorator.QueryAsync<SearchProductsByNameRepositoryResponse>("[dbo].[Products_SearchByName]", request);

    public Task<UpdateProductRepositoryResponse> UpdateAsync(UpdateProductRepositoryRequest request)
        => _connectionDecorator.QueryFirstAsync<UpdateProductRepositoryResponse>("[dbo].[Products_Update]", request);

    public Task<long> DeleteAsync(DeleteProductRepositoryRequest request)
        => _connectionDecorator.ExecuteScalarAsync<long>("[dbo].[Products_Delete]", request);

    public Task<ProductByIdRepositoryResponse?> GetByIdAsync(ProductByIdRepositoryRequest request)
        => _connectionDecorator.QueryFirstOrDefaultAsync<ProductByIdRepositoryResponse>("[dbo].[Products_GetById]", request);

    public Task<IEnumerable<ProductByIdsRepositoryResponse>> GetByIdsAsync(ProductByIdsRepositoryRequest request)
    {
        var idsDt = new DataTable();
        idsDt.Columns.Add("Value", typeof(long));

        foreach (var id in request.Ids)
        {
            var row = idsDt.NewRow();
            row["Value"] = id;
            idsDt.Rows.Add(row);
        }

        return _connectionDecorator.QueryAsync<ProductByIdsRepositoryResponse>("[dbo].[Products_GetByIds]", new
        {
            Ids = idsDt
        });
    }
}