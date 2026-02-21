using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.ProductCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.ProductHandlers
{
    //public class CreateProductCommandHandler(IRepository<Product> _repository,
    //    IUnitOfWork _unitOfWork,
    //    IValidator<Product> _validator) : IRequestHandler<CreateProductCommand, BaseResult<object>>
    //{
    //    public async Task<BaseResult<object>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    //    {
    //        var product = request.Adapt<Product>();

    //        var validationResult = await _validator.ValidateAsync(product);
    //        if (!validationResult.IsValid)
    //        {
    //            return BaseResult<object>.Fail(validationResult.Errors);
    //        }

    //        await _repository.CreateAsync(product);

    //        var result = await _unitOfWork.SaveChangesAsync();

    //        return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Ürün eklenemedi");
    //    }
    //}
}
