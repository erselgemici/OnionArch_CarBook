using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.ServiceCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.ServiceHandlers
{
    public class CreateServiceCommandHandler(IRepository<Service> _repository, IUnitOfWork _unitOfWork, IValidator<Service> _validator)
    : IRequestHandler<CreateServiceCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Adapt<Service>();
            var validation = await _validator.ValidateAsync(entity);
            if (!validation.IsValid) return BaseResult<object>.Fail(validation.Errors);

            await _repository.CreateAsync(entity);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Ekleme işlemi başarısız.");
        }
    }
}
