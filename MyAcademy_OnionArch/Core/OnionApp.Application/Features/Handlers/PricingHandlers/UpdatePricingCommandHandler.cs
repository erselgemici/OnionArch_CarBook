using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.PricingCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.PricingHandlers
{
    public class UpdatePricingCommandHandler(IRepository<Pricing> _repository, IUnitOfWork _unitOfWork, IValidator<Pricing> _validator)
    : IRequestHandler<UpdatePricingCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.PricingID);
            if (value == null) return BaseResult<object>.Fail("Güncellenecek kayıt bulunamadı.");

            request.Adapt(value);
            var validation = await _validator.ValidateAsync(value);
            if (!validation.IsValid) return BaseResult<object>.Fail(validation.Errors);

            _repository.Update(value);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Güncelleme yapılamadı.");
        }
    }
}
