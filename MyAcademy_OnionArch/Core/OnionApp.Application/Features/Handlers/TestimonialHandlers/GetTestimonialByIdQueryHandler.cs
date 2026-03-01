using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.TestimonialQueries;
using OnionApp.Application.Features.Results.TestimonialResults;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.TestimonialHandlers
{
    public class GetTestimonialByIdQueryHandler(IRepository<Testimonial> _repository) : IRequestHandler<GetTestimonialByIdQuery, BaseResult<GetTestimonialByIdQueryResult>>
    {
        public async Task<BaseResult<GetTestimonialByIdQueryResult>> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null) return BaseResult<GetTestimonialByIdQueryResult>.Fail("Müşteri yorumu bulunamadı.");
            return BaseResult<GetTestimonialByIdQueryResult>.Success(value.Adapt<GetTestimonialByIdQueryResult>());
        }
    }
}
