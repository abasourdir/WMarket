using MapsterMapper;
using WMarket.Data.Repositories.Product.Interfaces;
using WMarket.Data.Repositories.Product.Models.Request;
using WMarket.Modules.UseCases.Product.Update.Interfaces;
using WMarket.Modules.UseCases.Product.Update.Models.Request;
using WMarket.Modules.UseCases.Product.Update.Models.Response;

namespace WMarket.Modules.UseCases.Product.Update.Implementation;

public class UpdateProductModule : IUpdateProductModule
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public UpdateProductModule(
        IMapper mapper,
        IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<UpdateProductModuleResponse> ExecuteAsync(UpdateProductModuleRequest request)
    {
        var repositoryRequest = _mapper.From(request).AdaptToType<UpdateProductRepositoryRequest>();
        var repositoryResult = await _productRepository.UpdateAsync(repositoryRequest);
        return _mapper.From(repositoryResult).AdaptToType<UpdateProductModuleResponse>();
    }
}