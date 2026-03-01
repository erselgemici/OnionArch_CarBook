using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.TestimonialCommands;
using OnionApp.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class UpdateTestimonialCommandHandler(IRepository<Testimonial> _repository, IUnitOfWork _unitOfWork, IValidator<Testimonial> _validator)
    : IRequestHandler<UpdateTestimonialCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.TestimonialID);
            if (value == null) return BaseResult<object>.Fail("Güncellenecek kayıt bulunamadı.");

            request.Adapt(value);
            var validation = await _validator.ValidateAsync(value, cancellationToken);
            if (!validation.IsValid) return BaseResult<object>.Fail(validation.Errors);

            _repository.Update(value);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Güncelleme başarısız.");
        }
    }
}
