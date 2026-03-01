using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.FooterAddressCommands
{
    public record UpdateFooterAddressCommand(int FooterAddressID, string Description, string Address, string Phone, string Email) : IRequest<BaseResult<object>>;
}
