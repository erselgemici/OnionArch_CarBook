using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.LocationCommands
{
    public record CreateLocationCommand(string Name) : IRequest<BaseResult<object>>;
}
