using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.LocationQueries;
using OnionApp.Application.Features.Results.LocationResults;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.LocationHandlers
{
    public class GetLocationByIdQueryHandler(IRepository<Location> _repository) : IRequestHandler<GetLocationByIdQuery, BaseResult<GetLocationByIdQueryResult>>
    {
        public async Task<BaseResult<GetLocationByIdQueryResult>> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null) return BaseResult<GetLocationByIdQueryResult>.Fail("Lokasyon bulunamadı.");
            return BaseResult<GetLocationByIdQueryResult>.Success(value.Adapt<GetLocationByIdQueryResult>());
        }
    }
}
