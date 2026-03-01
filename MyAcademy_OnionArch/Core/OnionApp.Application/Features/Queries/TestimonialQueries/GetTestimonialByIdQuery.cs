using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.TestimonialResults;

namespace OnionApp.Application.Features.Queries.TestimonialQueries
{
    public record GetTestimonialByIdQuery(int Id) : IRequest<BaseResult<GetTestimonialByIdQueryResult>>;
}
