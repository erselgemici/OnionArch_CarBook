using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.TestimonialResults;

namespace OnionApp.Application.Features.Queries.TestimonialQueries
{
    public record GetTestimonialQuery() : IRequest<BaseResult<List<GetTestimonialQueryResult>>>;
}
