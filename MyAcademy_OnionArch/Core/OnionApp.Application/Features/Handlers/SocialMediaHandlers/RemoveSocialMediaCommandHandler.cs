using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.SocialMediaCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.SocialMediaHandlers
{
    public class RemoveSocialMediaCommandHandler(IRepository<SocialMedia> _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveSocialMediaCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null) return BaseResult<object>.Fail("Silinecek hesap bulunamadı.");
            _repository.Delete(value);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Silme işlemi başarısız.");
        }
    }
}
