using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.BrandResults;

namespace OnionApp.Application.Features.Queries.BrandQueries
{
    public record GetBrandByIdQuery(int Id) : IRequest<BaseResult<GetBrandByIdQueryResult>>;
}
