using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.FooterAddressCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.FooterAddressHandlers
{
    public class UpdateFooterAddressCommandHandler(IRepository<FooterAddress> _repository, IUnitOfWork _unitOfWork, IValidator<FooterAddress> _validator)
    : IRequestHandler<UpdateFooterAddressCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.FooterAddressID);
            if (value == null) return BaseResult<object>.Fail("Veri bulunamadı.");

            request.Adapt(value);
            var validation = await _validator.ValidateAsync(value);
            if (!validation.IsValid) return BaseResult<object>.Fail(validation.Errors);

            _repository.Update(value);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Güncelleme hatası.");
        }
    }
}
