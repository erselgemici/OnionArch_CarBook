using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.BannerCommands
{
    public record RemoveBannerCommand(int Id) : IRequest<BaseResult<object>>;
}
