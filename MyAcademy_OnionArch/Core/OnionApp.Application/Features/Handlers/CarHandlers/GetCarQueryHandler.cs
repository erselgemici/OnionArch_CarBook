using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Contracts.CarInterfaces;
using OnionApp.Application.Features.Queries.CarQueries;
using OnionApp.Application.Features.Results.CarResults;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.CarHandlers
{
    public class GetCarQueryHandler(ICarRepository _carRepository) : IRequestHandler<GetCarQuery, BaseResult<List<GetCarQueryResult>>>
    {
        public async Task<BaseResult<List<GetCarQueryResult>>> Handle(GetCarQuery request, CancellationToken cancellationToken)
        {
            var cars = await _carRepository.GetCarsWithBrandsAsync();

            var mapped = cars.Adapt<List<GetCarQueryResult>>();
            return BaseResult<List<GetCarQueryResult>>.Success(mapped);
        }
    }
}
