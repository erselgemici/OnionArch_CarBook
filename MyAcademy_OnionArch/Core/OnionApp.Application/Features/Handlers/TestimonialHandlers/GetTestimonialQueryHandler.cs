using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.TestimonialQueries;
using OnionApp.Application.Features.Results.TestimonialResults;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.TestimonialHandlers
{
    public class GetTestimonialQueryHandler(IRepository<Testimonial> _repository) : IRequestHandler<GetTestimonialQuery, BaseResult<List<GetTestimonialQueryResult>>>
    {
        public async Task<BaseResult<List<GetTestimonialQueryResult>>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return BaseResult<List<GetTestimonialQueryResult>>.Success(values.Adapt<List<GetTestimonialQueryResult>>());
        }
    }
}
