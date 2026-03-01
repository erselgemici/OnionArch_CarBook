using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.TestimonialCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class CreateTestimonialCommandHandler(IRepository<Testimonial> _repository, IUnitOfWork _unitOfWork, IValidator<Testimonial> _validator)
    : IRequestHandler<CreateTestimonialCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Adapt<Testimonial>();
            var validation = await _validator.ValidateAsync(entity, cancellationToken);
            if (!validation.IsValid) return BaseResult<object>.Fail(validation.Errors);

            await _repository.CreateAsync(entity);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Yorum kaydedilemedi.");
        }
    }
}
