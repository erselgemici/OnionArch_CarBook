using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.BrandCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler(IRepository<Brand> _repository, IUnitOfWork _unitOfWork, IValidator<Brand> _validator)
    : IRequestHandler<UpdateBrandCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _repository.GetByIdAsync(request.BrandID);
            if (brand == null) return BaseResult<object>.Fail("Marka bulunamadı.");

            request.Adapt(brand);
            var validation = await _validator.ValidateAsync(brand, cancellationToken);
            if (!validation.IsValid) return BaseResult<object>.Fail(validation.Errors);

            _repository.Update(brand);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Güncelleme başarısız.");
        }
    }
}
