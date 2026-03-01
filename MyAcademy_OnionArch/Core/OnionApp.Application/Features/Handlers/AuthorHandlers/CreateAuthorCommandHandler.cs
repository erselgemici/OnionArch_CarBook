using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.AuthorCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.AuthorHandlers
{
    public class CreateAuthorCommandHandler(IRepository<Author> _repository, IUnitOfWork _unitOfWork, IValidator<Author> _validator)
        : IRequestHandler<CreateAuthorCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Adapt<Author>();
            var validation = await _validator.ValidateAsync(entity, cancellationToken);
            if (!validation.IsValid) return BaseResult<object>.Fail(validation.Errors);

            await _repository.CreateAsync(entity);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Yazar eklenemedi.");
        }
    }
}
