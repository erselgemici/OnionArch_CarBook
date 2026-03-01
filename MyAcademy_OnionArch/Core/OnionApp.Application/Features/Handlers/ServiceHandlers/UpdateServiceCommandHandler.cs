using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.ServiceCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler(IRepository<Service> _repository, IUnitOfWork _unitOfWork, IValidator<Service> _validator)
    : IRequestHandler<UpdateServiceCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ServiceID);
            if (value == null) return BaseResult<object>.Fail("Güncellenecek hizmet bulunamadı.");

            request.Adapt(value);
            var validation = await _validator.ValidateAsync(value);
            if (!validation.IsValid) return BaseResult<object>.Fail(validation.Errors);

            _repository.Update(value);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Güncelleme yapılamadı.");
        }
    }
}
