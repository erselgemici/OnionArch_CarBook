using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.FooterAddressCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.FooterAddressHandlers
{
    public class RemoveFooterAddressCommandHandler(IRepository<FooterAddress> _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveFooterAddressCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null) return BaseResult<object>.Fail("Silinecek veri bulunamadı.");
            _repository.Delete(value);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Silme hatası.");
        }
    }
}
