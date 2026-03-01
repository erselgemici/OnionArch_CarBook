using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.PricingQueries;
using OnionApp.Application.Features.Results.PricingResults;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.PricingHandlers
{
    public class GetPricingQueryHandler(IRepository<Pricing> _repository) : IRequestHandler<GetPricingQuery, BaseResult<List<GetPricingQueryResult>>>
    {
        public async Task<BaseResult<List<GetPricingQueryResult>>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return BaseResult<List<GetPricingQueryResult>>.Success(values.Adapt<List<GetPricingQueryResult>>());
        }
    }
}
