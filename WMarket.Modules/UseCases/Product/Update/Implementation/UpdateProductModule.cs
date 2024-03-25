using WMarket.Common.Models.Enum;
using WMarket.Common.Models.Exceptions;
using WMarket.Data.Repositories.Product.Interfaces;
using WMarket.Modules.UseCases.Product.Update.Interfaces;
using WMarket.Modules.UseCases.Product.Update.Models.Request;
using WMarket.Modules.UseCases.Product.Update.Models.Response;

namespace WMarket.Modules.UseCases.Product.Update.Implementation;

public class UpdateProductModule : IUpdateProductModule
{
    private readonly IProductRepository _productRepository;

    public UpdateProductModule(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<UpdateProductModuleResponse> ExecuteAsync(UpdateProductModuleRequest request)
    {
        var product = await _productRepository.GetByIdAsync(new()
        {
            Id = request.Id
        });

        if (product is null)
            throw new BusinessException(ErrorCode.ProductNotFound, "Product not found");
        
        var updateResult = await _productRepository.UpdateAsync(new ()
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            Price = request.Price
        });
        
        return new UpdateProductModuleResponse
        {
            Id = updateResult.Id,
            Name = updateResult.Name,
            Description = updateResult.Description,
            Price = updateResult.Price
        };
    }
}