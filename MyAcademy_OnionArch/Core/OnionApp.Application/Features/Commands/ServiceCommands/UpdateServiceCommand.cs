using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.ServiceCommands
{
    public record UpdateServiceCommand(int ServiceID, string Title, string Description, string IconUrl) : IRequest<BaseResult<object>>;
}
