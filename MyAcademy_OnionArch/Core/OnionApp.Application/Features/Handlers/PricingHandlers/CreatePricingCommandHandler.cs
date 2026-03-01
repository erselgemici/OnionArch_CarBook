using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.PricingCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.PricingHandlers
{
    public class CreatePricingCommandHandler(IRepository<Pricing> _repository, IUnitOfWork _unitOfWork, IValidator<Pricing> _validator)
     : IRequestHandler<CreatePricingCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreatePricingCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Adapt<Pricing>();
            var validation = await _validator.ValidateAsync(entity);
            if (!validation.IsValid) return BaseResult<object>.Fail(validation.Errors);

            await _repository.CreateAsync(entity);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Ekleme başarısız.");
        }
    }
}
