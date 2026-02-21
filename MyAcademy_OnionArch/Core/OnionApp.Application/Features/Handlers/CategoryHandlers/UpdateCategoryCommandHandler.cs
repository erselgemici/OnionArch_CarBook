using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.CategoryCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler(IRepository<Category> _repository,
        IUnitOfWork _unitOfWork,
        IValidator<Category> _validator) : IRequestHandler<UpdateCategoryCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.CategoryID);

            if (category is null)
            {
                return BaseResult<object>.Fail("Bu Id'ye ait kategori bulunamadı");
            }

            category = request.Adapt(category);

            var validationResult = await _validator.ValidateAsync(category);
            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }

            _repository.Update(category);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Güncelleme başarısız.");
        }
    }
}
