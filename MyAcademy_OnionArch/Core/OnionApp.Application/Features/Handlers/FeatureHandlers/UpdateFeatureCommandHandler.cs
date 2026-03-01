using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.FeatureCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.FeatureHandlers
{
    public class UpdateFeatureCommandHandler(IRepository<Feature> _repository, IUnitOfWork _unitOfWork, IValidator<Feature> _validator)
    : IRequestHandler<UpdateFeatureCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.FeatureID);
            if (value == null) return BaseResult<object>.Fail("Güncellenecek veri bulunamadı.");

            request.Adapt(value);
            var validation = await _validator.ValidateAsync(value);
            if (!validation.IsValid) return BaseResult<object>.Fail(validation.Errors);

            _repository.Update(value);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Güncelleme başarısız.");
        }
    }
}
