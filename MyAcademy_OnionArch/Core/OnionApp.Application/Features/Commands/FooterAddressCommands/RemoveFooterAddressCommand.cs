using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.FooterAddressCommands
{
    public record RemoveFooterAddressCommand(int Id) : IRequest<BaseResult<object>>;
}
