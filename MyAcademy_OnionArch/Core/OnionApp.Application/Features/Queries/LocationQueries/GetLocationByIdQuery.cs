using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.LocationResults;

namespace OnionApp.Application.Features.Queries.LocationQueries
{
    public record GetLocationByIdQuery(int Id) : IRequest<BaseResult<GetLocationByIdQueryResult>>;
}
