using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.BrandResults;

namespace OnionApp.Application.Features.Queries.BrandQueries
{
    public record GetBrandQuery() : IRequest<BaseResult<List<GetBrandQueryResult>>>;
}
