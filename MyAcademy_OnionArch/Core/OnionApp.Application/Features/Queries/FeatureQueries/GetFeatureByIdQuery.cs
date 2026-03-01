using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.FeatureResults;

namespace OnionApp.Application.Features.Queries.FeatureQueries
{
    public record GetFeatureByIdQuery(int Id) : IRequest<BaseResult<GetFeatureByIdQueryResult>>;
}
