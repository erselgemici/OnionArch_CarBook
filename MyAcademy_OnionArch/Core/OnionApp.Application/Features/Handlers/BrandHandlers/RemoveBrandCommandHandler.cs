using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.BrandCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.BrandHandlers
{
    public class RemoveBrandCommandHandler(IRepository<Brand> _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveBrandCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _repository.GetByIdAsync(request.Id);
            if (brand == null) return BaseResult<object>.Fail("Silinecek marka bulunamadı.");

            _repository.Delete(brand);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Silme işlemi başarısız.");
        }
    }
}
