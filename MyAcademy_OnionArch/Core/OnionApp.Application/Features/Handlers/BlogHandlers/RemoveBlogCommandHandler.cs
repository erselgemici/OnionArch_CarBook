using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.BlogCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.BlogHandlers
{
    public class RemoveBlogCommandHandler(IRepository<Blog> _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveBlogCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null) return BaseResult<object>.Fail("Silinecek blog yazısı bulunamadı.");

            _repository.Delete(value);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Silme işlemi başarısız.");
        }
    }
}
