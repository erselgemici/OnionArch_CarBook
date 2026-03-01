using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.FooterAddressQueries;
using OnionApp.Application.Features.Results.FooterAddressResults;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressQueryHandler(IRepository<FooterAddress> _repository) : IRequestHandler<GetFooterAddressQuery, BaseResult<List<GetFooterAddressQueryResult>>>
    {
        public async Task<BaseResult<List<GetFooterAddressQueryResult>>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return BaseResult<List<GetFooterAddressQueryResult>>.Success(values.Adapt<List<GetFooterAddressQueryResult>>());
        }
    }
}
