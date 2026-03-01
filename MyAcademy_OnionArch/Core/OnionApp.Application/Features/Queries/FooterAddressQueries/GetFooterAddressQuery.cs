using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.FooterAddressResults;

namespace OnionApp.Application.Features.Queries.FooterAddressQueries;

public record GetFooterAddressQuery() : IRequest<BaseResult<List<GetFooterAddressQueryResult>>>;
