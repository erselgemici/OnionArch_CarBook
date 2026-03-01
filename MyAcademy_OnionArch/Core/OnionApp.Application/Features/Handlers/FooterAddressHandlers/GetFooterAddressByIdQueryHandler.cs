using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.FooterAddressQueries;
using OnionApp.Application.Features.Results.FooterAddressResults;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> _repository) : IRequestHandler<GetFooterAddressByIdQuery, BaseResult<GetFooterAddressByIdQueryResult>>
    {
        public async Task<BaseResult<GetFooterAddressByIdQueryResult>> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null) return BaseResult<GetFooterAddressByIdQueryResult>.Fail("Adres bilgisi bulunamadı.");
            return BaseResult<GetFooterAddressByIdQueryResult>.Success(value.Adapt<GetFooterAddressByIdQueryResult>());
        }
    }
}
