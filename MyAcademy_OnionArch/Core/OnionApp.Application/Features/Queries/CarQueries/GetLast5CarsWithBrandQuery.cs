using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.CarResults;

namespace OnionApp.Application.Features.Queries.CarQueries
{
    public record GetLast5CarsWithBrandQuery() : IRequest<BaseResult<List<GetCarQueryResult>>>;
}
