using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.CarCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler(IRepository<Car> _repository, IUnitOfWork _unitOfWork, IValidator<Car> _validator)
     : IRequestHandler<UpdateCarCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var car = await _repository.GetByIdAsync(request.CarID);
            if (car == null) return BaseResult<object>.Fail("Araç bulunamadı.");

            request.Adapt(car);
            var validation = await _validator.ValidateAsync(car, cancellationToken);
            if (!validation.IsValid) return BaseResult<object>.Fail(validation.Errors);

            _repository.Update(car);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Güncelleme başarısız.");
        }
    }
}
