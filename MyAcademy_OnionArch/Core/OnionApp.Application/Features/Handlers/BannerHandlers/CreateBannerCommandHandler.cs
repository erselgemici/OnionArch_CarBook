using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.BannerCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.BannerHandlers
{
    public class CreateBannerCommandHandler(IRepository<Banner> _repository, IUnitOfWork _unitOfWork, IValidator<Banner> _validator)
    : IRequestHandler<CreateBannerCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateBannerCommand request, CancellationToken cancellationToken)
        {
            var banner = request.Adapt<Banner>();
            var validation = await _validator.ValidateAsync(banner);
            if (!validation.IsValid) return BaseResult<object>.Fail(validation.Errors);

            await _repository.CreateAsync(banner);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Kaydedilemedi.");
        }
    }
}
