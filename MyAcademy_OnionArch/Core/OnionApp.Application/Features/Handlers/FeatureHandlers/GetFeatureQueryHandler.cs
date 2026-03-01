using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.FeatureQueries;
using OnionApp.Application.Features.Results.FeatureResults;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.FeatureHandlers
{
    public class GetFeatureQueryHandler(IRepository<Feature> _repository) : IRequestHandler<GetFeatureQuery, BaseResult<List<GetFeatureQueryResult>>>
    {
        public async Task<BaseResult<List<GetFeatureQueryResult>>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return BaseResult<List<GetFeatureQueryResult>>.Success(values.Adapt<List<GetFeatureQueryResult>>());
        }
    }

    
}
