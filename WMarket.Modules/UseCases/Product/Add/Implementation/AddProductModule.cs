using WMarket.Data.Repositories.Product.Interfaces;
using WMarket.Modules.UseCases.Product.Add.Interfaces;
using WMarket.Modules.UseCases.Product.Add.Models.Request;
using WMarket.Modules.UseCases.Product.Add.Models.Response;

namespace WMarket.Modules.UseCases.Product.Add.Implementation;

public class AddProductModule : IAddProductModule
{
    private readonly IProductRepository _productRepository;

    public AddProductModule(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<AddProductModuleResponse> ExecuteAsync(AddProductModuleRequest request)
    {
        var id = await _productRepository.InsertAsync(new ()
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price
        });
        
        return new AddProductModuleResponse
        {
            Id = id
        };
    }
}