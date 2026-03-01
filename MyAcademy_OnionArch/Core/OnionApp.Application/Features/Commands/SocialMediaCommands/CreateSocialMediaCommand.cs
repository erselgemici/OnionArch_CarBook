using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.SocialMediaCommands
{
    public record CreateSocialMediaCommand(string Name, string Url, string Icon) : IRequest<BaseResult<object>>;
}
