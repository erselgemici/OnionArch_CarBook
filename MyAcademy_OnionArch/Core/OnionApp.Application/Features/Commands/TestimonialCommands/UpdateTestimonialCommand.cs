using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.TestimonialCommands
{
    public record UpdateTestimonialCommand(int TestimonialID, string Name, string Title, string Comment, string ImageUrl) : IRequest<BaseResult<object>>;
}
