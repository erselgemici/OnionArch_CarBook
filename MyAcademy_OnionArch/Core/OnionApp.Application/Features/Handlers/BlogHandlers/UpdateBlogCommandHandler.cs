using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.BlogCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.BlogHandlers
{
    public class UpdateBlogCommandHandler(IRepository<Blog> _repository, IUnitOfWork _unitOfWork, IValidator<Blog> _validator)
         : IRequestHandler<UpdateBlogCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.BlogID);
            if (value == null) return BaseResult<object>.Fail("Güncellenecek blog yazısı bulunamadı.");

            request.Adapt(value);
            var validation = await _validator.ValidateAsync(value, cancellationToken);
            if (!validation.IsValid) return BaseResult<object>.Fail(validation.Errors);

            _repository.Update(value);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Güncelleme işlemi başarısız.");
        }
    }
}
