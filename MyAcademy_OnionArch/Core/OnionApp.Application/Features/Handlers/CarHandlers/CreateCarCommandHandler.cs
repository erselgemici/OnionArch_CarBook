using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.CarCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.CarHandlers
{
    public class CreateCarCommandHandler(IRepository<Car> _repository, IUnitOfWork _unitOfWork, IValidator<Car> _validator)
    : IRequestHandler<CreateCarCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var car = request.Adapt<Car>();
            var validation = await _validator.ValidateAsync(car, cancellationToken);
            if (!validation.IsValid) return BaseResult<object>.Fail(validation.Errors);

            await _repository.CreateAsync(car);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Araç kaydedilemedi.");
        }
    }
}
