using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.CategoryCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler(
        IRepository<Category> _repository,
        IUnitOfWork _unitOfWork,
        IValidator<Category> _validator) : IRequestHandler<CreateCategoryCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = request.Adapt<Category>();

            var validationResult = await _validator.ValidateAsync(category);

            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }

            await _repository.CreateAsync(category);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Kategori kaydedilemedi.");

        }
    }
}
