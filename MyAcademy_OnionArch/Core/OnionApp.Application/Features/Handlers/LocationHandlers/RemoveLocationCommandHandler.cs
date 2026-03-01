using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.LocationCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.LocationHandlers
{
    public class RemoveLocationCommandHandler(IRepository<Location> _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveLocationCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveLocationCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null) return BaseResult<object>.Fail("Silinecek lokasyon bulunamadı.");
            _repository.Delete(value);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Silme işlemi başarısız.");
        }
    }
}
