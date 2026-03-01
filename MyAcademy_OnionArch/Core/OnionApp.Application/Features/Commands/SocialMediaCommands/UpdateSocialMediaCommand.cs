using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.SocialMediaCommands
{
    public record UpdateSocialMediaCommand(int SocialMediaID, string Name, string Url, string Icon) : IRequest<BaseResult<object>>;
}
