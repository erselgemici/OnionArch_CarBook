using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.AboutCommands;
using OnionApp.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.AboutHandlers
{
    public class CreateAboutCommandHandler(
        IRepository<About> _repository,
        IUnitOfWork _unitOfWork,
        IValidator<About> _validator) : IRequestHandler<CreateAboutCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateAboutCommand request, CancellationToken cancellationToken)
        {
            var about = request.Adapt<About>();

            var validationResult = await _validator.ValidateAsync(about, cancellationToken);

            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }

            await _repository.CreateAsync(about);

            var result = await _unitOfWork.SaveChangesAsync();

            return result
                ? BaseResult<object>.Success()
                : BaseResult<object>.Fail("Hakkımda bilgisi kaydedilemedi.");
        }
    }
}
