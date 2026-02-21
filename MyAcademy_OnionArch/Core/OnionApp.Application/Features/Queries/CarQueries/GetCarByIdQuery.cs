using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.CarResults;

namespace OnionApp.Application.Features.Queries.CarQueries
{
    public record GetCarByIdQuery(int Id) : IRequest<BaseResult<GetCarByIdQueryResult>>;
}
