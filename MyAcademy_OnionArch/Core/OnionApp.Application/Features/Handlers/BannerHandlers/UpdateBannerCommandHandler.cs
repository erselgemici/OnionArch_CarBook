using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.BannerCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler(IRepository<Banner> _repository, IUnitOfWork _unitOfWork, IValidator<Banner> _validator)
    : IRequestHandler<UpdateBannerCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateBannerCommand request, CancellationToken cancellationToken)
        {
            var banner = await _repository.GetByIdAsync(request.BannerId);
            if (banner == null) return BaseResult<object>.Fail("Banner bulunamadı.");

            request.Adapt(banner);
            var validation = await _validator.ValidateAsync(banner);
            if (!validation.IsValid) return BaseResult<object>.Fail(validation.Errors);

            _repository.Update(banner);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Güncellenemedi.");
        }
    }
}
