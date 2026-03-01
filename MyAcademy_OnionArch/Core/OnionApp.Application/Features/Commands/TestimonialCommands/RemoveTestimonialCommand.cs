using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.TestimonialCommands
{
    public record RemoveTestimonialCommand(int Id) : IRequest<BaseResult<object>>;
}
