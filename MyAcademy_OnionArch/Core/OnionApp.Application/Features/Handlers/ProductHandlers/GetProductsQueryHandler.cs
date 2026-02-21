using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.ProductQueries;
using OnionApp.Application.Features.Results.ProductResults;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.ProductHandlers
{
    //public class GetProductsQueryHandler(IRepository<Product> _repository) : IRequestHandler<GetProductsQuery, BaseResult<List<GetProductsQueryResult>>>
    //{
    //    public async Task<BaseResult<List<GetProductsQueryResult>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    //    {
    //        var products = await _repository.GetAllAsync();

    //        var mappedProducts = products.Adapt<List<GetProductsQueryResult>>();

    //        return BaseResult<List<GetProductsQueryResult>>.Success(mappedProducts);
    //    }
    //}
}
