using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.FooterAddressCommands
{
    public record CreateFooterAddressCommand(string Description, string Address, string Phone, string Email) : IRequest<BaseResult<object>>;
}
