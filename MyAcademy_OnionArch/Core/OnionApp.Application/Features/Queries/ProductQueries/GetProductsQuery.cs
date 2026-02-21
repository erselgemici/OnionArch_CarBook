using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.ProductResults;

namespace OnionApp.Application.Features.Queries.ProductQueries
{
    public class GetProductsQuery : IRequest<BaseResult<List<GetProductsQueryResult>>>
    {
    }
}
