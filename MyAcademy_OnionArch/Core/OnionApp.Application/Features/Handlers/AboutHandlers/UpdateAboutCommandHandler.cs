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
    public class UpdateAboutCommandHandler(
        IRepository<About> _repository,
        IUnitOfWork _unitOfWork,
        IValidator<About> _validator) : IRequestHandler<UpdateAboutCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {
            var about = await _repository.GetByIdAsync(request.AboutId);

            if (about is null)
            {
                return BaseResult<object>.Fail("Bu Id'ye ait hakkımda bilgisi bulunamadı.");
            }
       
            request.Adapt(about);

            var validationResult = await _validator.ValidateAsync(about, cancellationToken);
            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }

            _repository.Update(about);
            var result = await _unitOfWork.SaveChangesAsync();

            return result
                ? BaseResult<object>.Success()
                : BaseResult<object>.Fail("Güncelleme işlemi başarısız oldu.");
        }
    }
}
