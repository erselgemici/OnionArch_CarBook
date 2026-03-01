using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.PricingResults;

namespace OnionApp.Application.Features.Queries.PricingQueries
{
    public record GetPricingQuery() : IRequest<BaseResult<List<GetPricingQueryResult>>>;
}
