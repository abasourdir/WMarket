using MapsterMapper;
using WMarket.Data.Repositories.Product.Interfaces;
using WMarket.Data.Repositories.Product.Models.Request;
using WMarket.Modules.UseCases.Product.Add.Interfaces;
using WMarket.Modules.UseCases.Product.Add.Models.Request;
using WMarket.Modules.UseCases.Product.Add.Models.Response;

namespace WMarket.Modules.UseCases.Product.Add.Implementation;

public class AddProductModule : IAddProductModule
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public AddProductModule(
        IMapper mapper,
        IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }
    
    public async Task<AddProductModuleResponse> ExecuteAsync(AddProductModuleRequest request)
    {
        var repositoryRequest = _mapper.From(request).AdaptToType<InsertProductRepositoryRequest>();
        var id = await _productRepository.InsertAsync(repositoryRequest);
        
        return new AddProductModuleResponse
        {
            Id = id
        };
    }
}