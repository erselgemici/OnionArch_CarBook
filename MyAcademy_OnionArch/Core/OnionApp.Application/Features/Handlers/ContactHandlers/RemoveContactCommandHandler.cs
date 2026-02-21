using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.ContactCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.ContactHandlers
{
    public class RemoveContactCommandHandler(IRepository<Contact> _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveContactCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveContactCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            if (value == null)
            {
                return BaseResult<object>.Fail("Silinecek mesaj bulunamadı.");
            }

            _repository.Delete(value);
            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Silme işlemi gerçekleştirilemedi.");
        }
    }
}
