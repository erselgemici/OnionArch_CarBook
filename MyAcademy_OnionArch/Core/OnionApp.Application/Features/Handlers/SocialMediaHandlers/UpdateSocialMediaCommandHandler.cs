using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.SocialMediaCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.SocialMediaHandlers
{
    public class UpdateSocialMediaCommandHandler(IRepository<SocialMedia> _repository, IUnitOfWork _unitOfWork, IValidator<SocialMedia> _validator)
     : IRequestHandler<UpdateSocialMediaCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.SocialMediaID);
            if (value == null) return BaseResult<object>.Fail("Güncellenecek hesap bulunamadı.");

            request.Adapt(value);
            var validation = await _validator.ValidateAsync(value);
            if (!validation.IsValid) return BaseResult<object>.Fail(validation.Errors);

            _repository.Update(value);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Güncelleme yapılamadı.");
        }
    }
}
