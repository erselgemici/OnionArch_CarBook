using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.LocationCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.LocationHandlers
{
    public class CreateLocationCommandHandler(IRepository<Location> _repository, IUnitOfWork _unitOfWork, IValidator<Location> _validator)
     : IRequestHandler<CreateLocationCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Adapt<Location>();
            var validation = await _validator.ValidateAsync(entity);
            if (!validation.IsValid) return BaseResult<object>.Fail(validation.Errors);

            await _repository.CreateAsync(entity);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Ekleme sırasında bir hata oluştu.");
        }
    }
}
