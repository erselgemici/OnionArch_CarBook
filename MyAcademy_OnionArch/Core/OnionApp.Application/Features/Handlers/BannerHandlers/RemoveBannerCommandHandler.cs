using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.BannerCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.BannerHandlers
{
    public class RemoveBannerCommandHandler(IRepository<Banner> _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveBannerCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveBannerCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null) return BaseResult<object>.Fail("Banner bulunamadı.");
            _repository.Delete(value);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Silinemedi.");
        }
    }
}
