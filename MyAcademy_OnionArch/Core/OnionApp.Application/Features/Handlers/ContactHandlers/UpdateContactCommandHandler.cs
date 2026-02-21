using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.ContactCommands;
using OnionApp.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler(
        IRepository<Contact> _repository,
        IUnitOfWork _unitOfWork,
        IValidator<Contact> _validator) : IRequestHandler<UpdateContactCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.ContactID);

            if (values == null)
            {
                return BaseResult<object>.Fail("Güncellenecek mesaj bulunamadı.");
            }

            request.Adapt(values);

            var validationResult = await _validator.ValidateAsync(values, cancellationToken);
            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }

            _repository.Update(values);
            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Güncelleme işlemi başarısız.");
        }
    }
}
