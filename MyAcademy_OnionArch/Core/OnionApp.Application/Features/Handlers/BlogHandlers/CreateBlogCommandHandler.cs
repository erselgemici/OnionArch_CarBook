using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.BlogCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.BlogHandlers
{
    public class CreateBlogCommandHandler(IRepository<Blog> _repository, IUnitOfWork _unitOfWork, IValidator<Blog> _validator)
        : IRequestHandler<CreateBlogCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Adapt<Blog>();
            var validation = await _validator.ValidateAsync(entity, cancellationToken);
            if (!validation.IsValid) return BaseResult<object>.Fail(validation.Errors);

            await _repository.CreateAsync(entity);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Blog yazısı eklenemedi.");
        }
    }
}
