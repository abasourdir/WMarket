using MapsterMapper;
using WMarket.Data.Repositories.Product.Interfaces;
using WMarket.Data.Repositories.Product.Models.Request;
using WMarket.Modules.UseCases.Product.Delete.Interfaces;
using WMarket.Modules.UseCases.Product.Delete.Models.Request;
using WMarket.Modules.UseCases.Product.Delete.Models.Response;

namespace WMarket.Modules.UseCases.Product.Delete.Implementation;

public class DeleteProductModule : IDeleteProductModule
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public DeleteProductModule(
        IMapper mapper,
        IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }
    
    public async Task<DeleteProductModuleResponse> ExecuteAsync(DeleteProductModuleRequest request)
    {
        var repositoryRequest = _mapper.From(request).AdaptToType<DeleteProductRepositoryRequest>();
        var id = await _productRepository.DeleteAsync(repositoryRequest);
        
        return new DeleteProductModuleResponse
        {
            Id = id
        };
    }
}