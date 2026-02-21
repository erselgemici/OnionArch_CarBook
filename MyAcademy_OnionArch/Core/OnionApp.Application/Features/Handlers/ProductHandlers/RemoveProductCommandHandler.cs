using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.ProductCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.ProductHandlers
{
    //public class RemoveProductCommandHandler(IRepository<Product> _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveProductCommand, BaseResult<object>>
    //{
    //    public async Task<BaseResult<object>> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
    //    {
    //        var product = await _repository.GetByIdAsync(request.Id);

    //        if (product is null)
    //        {
    //            return BaseResult<object>.Fail("Ürün bulunamadı");
    //        }

    //        _repository.Delete(product);

    //        var result = await _unitOfWork.SaveChangesAsync();

    //        return result ? BaseResult<object>.Success() :  BaseResult<object>.Fail("Ürün silinemedi.");

    //    }
    //}
}
