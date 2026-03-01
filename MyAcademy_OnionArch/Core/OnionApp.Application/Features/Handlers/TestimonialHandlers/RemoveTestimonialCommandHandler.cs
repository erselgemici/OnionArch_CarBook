using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.TestimonialCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.TestimonialHandlers
{
    public class RemoveTestimonialCommandHandler(IRepository<Testimonial> _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveTestimonialCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null) return BaseResult<object>.Fail("Silinecek kayıt bulunamadı.");
            _repository.Delete(value);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Silme işlemi yapılamadı.");
        }
    }
}
