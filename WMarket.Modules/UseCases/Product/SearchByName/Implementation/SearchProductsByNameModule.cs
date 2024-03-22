using MapsterMapper;
using WMarket.Data.Repositories.Product.Interfaces;
using WMarket.Modules.UseCases.Product.SearchByName.Interfaces;
using WMarket.Modules.UseCases.Product.SearchByName.Models.Request;
using WMarket.Modules.UseCases.Product.SearchByName.Models.Response;

namespace WMarket.Modules.UseCases.Product.SearchByName.Implementation;

public class SearchProductsByNameModule : ISearchProductsByNameModule
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public SearchProductsByNameModule(
        IMapper mapper,
        IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }
    
    public async Task<SearchProductsByNameModuleResponse> ExecuteAsync(SearchProductsByNameModuleRequest request)
    {
        var result = await _productRepository.SearchByNameAsync(new()
        {
            Name = request.Name,
            Limit = request.Limit,
            Offset = request.CurrentPage > 1
                ? request.Limit * (request.CurrentPage.Value - 1)
                : 0
        });

        return new SearchProductsByNameModuleResponse
        {
            Data = _mapper.From(result).AdaptToType<List<SearchProductsByNameModuleResponseData>>()
        };
    }
}