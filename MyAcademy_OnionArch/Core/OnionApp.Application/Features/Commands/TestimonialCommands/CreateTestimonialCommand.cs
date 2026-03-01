using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.TestimonialCommands
{
    public record CreateTestimonialCommand(string Name, string Title, string Comment, string ImageUrl) : IRequest<BaseResult<object>>;
}
