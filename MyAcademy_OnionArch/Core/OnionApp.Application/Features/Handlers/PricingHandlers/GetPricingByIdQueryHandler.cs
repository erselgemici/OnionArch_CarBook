using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.PricingQueries;
using OnionApp.Application.Features.Results.PricingResults;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.PricingHandlers
{
    public class GetPricingByIdQueryHandler(IRepository<Pricing> _repository) : IRequestHandler<GetPricingByIdQuery, BaseResult<GetPricingByIdQueryResult>>
    {
        public async Task<BaseResult<GetPricingByIdQueryResult>> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null) return BaseResult<GetPricingByIdQueryResult>.Fail("Fiyatlandırma türü bulunamadı.");
            return BaseResult<GetPricingByIdQueryResult>.Success(value.Adapt<GetPricingByIdQueryResult>());
        }
    }
}
