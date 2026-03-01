using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.SocialMediaCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.SocialMediaHandlers
{
    public class CreateSocialMediaCommandHandler(IRepository<SocialMedia> _repository, IUnitOfWork _unitOfWork, IValidator<SocialMedia> _validator)
     : IRequestHandler<CreateSocialMediaCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Adapt<SocialMedia>();
            var validation = await _validator.ValidateAsync(entity);
            if (!validation.IsValid) return BaseResult<object>.Fail(validation.Errors);

            await _repository.CreateAsync(entity);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Ekleme işlemi başarısız.");
        }
    }
}
