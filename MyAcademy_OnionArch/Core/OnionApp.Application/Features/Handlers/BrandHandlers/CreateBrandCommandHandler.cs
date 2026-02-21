using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.BrandCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.BrandHandlers
{
    public class CreateBrandCommandHandler(IRepository<Brand> _repository, IUnitOfWork _unitOfWork, IValidator<Brand> _validator)
    : IRequestHandler<CreateBrandCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = request.Adapt<Brand>();
            var validation = await _validator.ValidateAsync(brand, cancellationToken);
            if (!validation.IsValid) return BaseResult<object>.Fail(validation.Errors);

            await _repository.CreateAsync(brand);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Marka kaydedilemedi.");
        }
    }
}
