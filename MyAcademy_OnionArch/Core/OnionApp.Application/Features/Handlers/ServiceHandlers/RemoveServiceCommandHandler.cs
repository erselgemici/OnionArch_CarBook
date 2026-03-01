using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.ServiceCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.ServiceHandlers
{
    public class RemoveServiceCommandHandler(IRepository<Service> _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveServiceCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null) return BaseResult<object>.Fail("Silinecek hizmet bulunamadı.");
            _repository.Delete(value);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Silme işlemi başarısız.");
        }
    }
}
