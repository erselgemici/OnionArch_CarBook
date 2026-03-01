using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.SocialMediaCommands
{
    public record RemoveSocialMediaCommand(int Id) : IRequest<BaseResult<object>>;
}
