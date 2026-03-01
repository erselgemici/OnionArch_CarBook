using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.LocationQueries;
using OnionApp.Application.Features.Results.LocationResults;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.LocationHandlers
{
    public class GetLocationQueryHandler(IRepository<Location> _repository) : IRequestHandler<GetLocationQuery, BaseResult<List<GetLocationQueryResult>>>
    {
        public async Task<BaseResult<List<GetLocationQueryResult>>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return BaseResult<List<GetLocationQueryResult>>.Success(values.Adapt<List<GetLocationQueryResult>>());
        }
    }
}
