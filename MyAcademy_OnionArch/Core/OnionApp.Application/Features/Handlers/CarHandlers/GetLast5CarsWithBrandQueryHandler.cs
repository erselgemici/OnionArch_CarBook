using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts.CarInterfaces;
using OnionApp.Application.Features.Queries.CarQueries;
using OnionApp.Application.Features.Results.CarResults;

namespace OnionApp.Application.Features.Handlers.CarHandlers
{
    
    public class GetLast5CarsWithBrandQueryHandler(ICarRepository _repository)
        : IRequestHandler<GetLast5CarsWithBrandQuery, BaseResult<List<GetCarQueryResult>>>
    {
        public async Task<BaseResult<List<GetCarQueryResult>>> Handle(GetLast5CarsWithBrandQuery request, CancellationToken cancellationToken)
        {

            var values = await _repository.GetLast5CarsWithBrandsAsync();
            return BaseResult<List<GetCarQueryResult>>.Success(values.Adapt<List<GetCarQueryResult>>());
        }
    }
}
