using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.AboutCommands;
using OnionApp.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.AboutHandlers
{
    public class RemoveAboutCommandHandler(
        IRepository<About> _repository,
        IUnitOfWork _unitOfWork) : IRequestHandler<RemoveAboutCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveAboutCommand request, CancellationToken cancellationToken)
        {
            var about = await _repository.GetByIdAsync(request.Id);

            if (about is null)
            {
                return BaseResult<object>.Fail("Hakkımda bilgisi bulunamadı.");
            }

            _repository.Delete(about);

            var result = await _unitOfWork.SaveChangesAsync();

            return result
                ? BaseResult<object>.Success()
                : BaseResult<object>.Fail("Hakkımda bilgisi silinemedi.");
        }
    }
}
