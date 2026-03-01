using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.FeatureCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.FeatureHandlers
{
    public class CreateFeatureCommandHandler(IRepository<Feature> _repository, IUnitOfWork _unitOfWork, IValidator<Feature> _validator)
    : IRequestHandler<CreateFeatureCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            var feature = request.Adapt<Feature>();
            var validation = await _validator.ValidateAsync(feature);
            if (!validation.IsValid) return BaseResult<object>.Fail(validation.Errors);

            await _repository.CreateAsync(feature);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Kayıt sırasında hata oluştu.");
        }
    }
}
