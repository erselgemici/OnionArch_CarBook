using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.LocationCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.LocationHandlers
{
    public class UpdateLocationCommandHandler(IRepository<Location> _repository, IUnitOfWork _unitOfWork, IValidator<Location> _validator)
    : IRequestHandler<UpdateLocationCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.LocationID);
            if (value == null) return BaseResult<object>.Fail("Güncellenecek lokasyon bulunamadı.");

            request.Adapt(value);
            var validation = await _validator.ValidateAsync(value);
            if (!validation.IsValid) return BaseResult<object>.Fail(validation.Errors);

            _repository.Update(value);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Güncelleme yapılamadı.");
        }
    }
}
