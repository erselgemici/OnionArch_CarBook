using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.FooterAddressCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.FooterAddressHandlers
{
    public class CreateFooterAddressCommandHandler(IRepository<FooterAddress> _repository, IUnitOfWork _unitOfWork, IValidator<FooterAddress> _validator)
    : IRequestHandler<CreateFooterAddressCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Adapt<FooterAddress>();
            var validation = await _validator.ValidateAsync(entity);
            if (!validation.IsValid) return BaseResult<object>.Fail(validation.Errors);

            await _repository.CreateAsync(entity);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Ekleme hatası.");
        }
    }
}
