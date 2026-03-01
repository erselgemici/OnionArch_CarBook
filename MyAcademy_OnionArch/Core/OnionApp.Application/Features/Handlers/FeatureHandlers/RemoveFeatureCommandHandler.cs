using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.FeatureCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.FeatureHandlers
{
    public class RemoveFeatureCommandHandler(IRepository<Feature> _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveFeatureCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null) return BaseResult<object>.Fail("Silinecek veri bulunamadı.");
            _repository.Delete(value);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Silme işlemi başarısız.");
        }
    }
}
