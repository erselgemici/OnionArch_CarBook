using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.BannerCommands
{
    public record UpdateBannerCommand(int BannerId, string Title, string Description, string VideoDescription, string VideoUrl) : IRequest<BaseResult<object>>;
}
