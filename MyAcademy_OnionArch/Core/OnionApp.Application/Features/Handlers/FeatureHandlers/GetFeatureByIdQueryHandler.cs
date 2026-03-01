using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.FeatureQueries;
using OnionApp.Application.Features.Results.FeatureResults;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.FeatureHandlers
{
    public class GetFeatureByIdQueryHandler(IRepository<Feature> _repository) : IRequestHandler<GetFeatureByIdQuery, BaseResult<GetFeatureByIdQueryResult>>
    {
        public async Task<BaseResult<GetFeatureByIdQueryResult>> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null) return BaseResult<GetFeatureByIdQueryResult>.Fail("Özellik bulunamadı.");
            return BaseResult<GetFeatureByIdQueryResult>.Success(value.Adapt<GetFeatureByIdQueryResult>());
        }
    }
}
