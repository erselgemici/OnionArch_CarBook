using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.CarCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.CarHandlers
{
    public class RemoveCarCommandHandler(IRepository<Car> _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveCarCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveCarCommand request, CancellationToken cancellationToken)
        {
            var car = await _repository.GetByIdAsync(request.Id);
            if (car == null) return BaseResult<object>.Fail("Silinecek araç bulunamadı.");
            _repository.Delete(car);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Silme işlemi başarısız.");
        }
    }
}
