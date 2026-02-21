using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.ProductCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.ProductHandlers
{
    //public class UpdateProductCommandHandler(IRepository<Product> _repository,
    //                                         IUnitOfWork _unitOfWork,
    //                                         IValidator<Product> _validator,
    //                                         IRepository<Category> _categoryRepository) : IRequestHandler<UpdateProductCommand, BaseResult<object>>
    //{
    //    public async Task<BaseResult<object>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    //    {
    //        var product = await _repository.GetByIdAsync(request.Id);

    //        if (product is null)
    //        {
    //            return BaseResult<object>.Fail("Ürün bulunamadı");
    //        }

    //        product = request.Adapt(product);

    //        var category = await _categoryRepository.GetByIdAsync(request.CategoryId);

    //        if (category is null)
    //        {
    //            return BaseResult<object>.Fail("Bu kategori bulunamadı");
    //        }


    //        var validationResult = await _validator.ValidateAsync(product);
    //        if (!validationResult.IsValid)
    //        {
    //            return BaseResult<object>.Fail(validationResult.Errors);
    //        }

    //        _repository.Update(product);
    //        var result = await _unitOfWork.SaveChangesAsync();

    //        return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Ürün güncellenemedi");
    //    }
    //}
}
