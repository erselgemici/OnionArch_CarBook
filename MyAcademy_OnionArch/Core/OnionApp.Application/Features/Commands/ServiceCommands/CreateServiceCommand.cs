using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.ServiceCommands
{
    public record CreateServiceCommand(string Title, string Description, string IconUrl) : IRequest<BaseResult<object>>;
}
