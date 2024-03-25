using WMarket.Common.Models.Enum;
using WMarket.Common.Models.Exceptions;
using WMarket.Data.Repositories.Product.Interfaces;
using WMarket.Modules.UseCases.Product.Delete.Interfaces;
using WMarket.Modules.UseCases.Product.Delete.Models.Request;
using WMarket.Modules.UseCases.Product.Delete.Models.Response;

namespace WMarket.Modules.UseCases.Product.Delete.Implementation;

public class DeleteProductModule : IDeleteProductModule
{
    private readonly IProductRepository _productRepository;

    public DeleteProductModule(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<DeleteProductModuleResponse> ExecuteAsync(DeleteProductModuleRequest request)
    {
        var product = await _productRepository.GetByIdAsync(new()
        {
            Id = request.Id
        });

        if (product is null)
            throw new BusinessException(ErrorCode.ProductNotFound, "Product not found");
        
        var id = await _productRepository.DeleteAsync(new ()
        {
            Id = request.Id
        });
        
        return new DeleteProductModuleResponse
        {
            Id = id
        };
    }
}