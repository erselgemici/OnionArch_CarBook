using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.AuthorCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.AuthorHandlers
{
    public class UpdateAuthorCommandHandler(IRepository<Author> _repository, IUnitOfWork _unitOfWork, IValidator<Author> _validator)
        : IRequestHandler<UpdateAuthorCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.AuthorID);
            if (value == null) return BaseResult<object>.Fail("Güncellenecek yazar bulunamadı.");

            request.Adapt(value);
            var validation = await _validator.ValidateAsync(value, cancellationToken);
            if (!validation.IsValid) return BaseResult<object>.Fail(validation.Errors);

            _repository.Update(value);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Güncelleme işlemi başarısız.");
        }
    }
}
