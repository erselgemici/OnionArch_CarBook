using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.ServiceResults;

namespace OnionApp.Application.Features.Queries.ServiceQueries
{
    public record GetServiceByIdQuery(int Id) : IRequest<BaseResult<GetServiceByIdQueryResult>>;
}
