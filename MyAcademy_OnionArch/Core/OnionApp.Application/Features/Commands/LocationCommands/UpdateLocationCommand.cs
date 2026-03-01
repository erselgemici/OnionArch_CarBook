using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.LocationCommands
{
    public record UpdateLocationCommand(int LocationID, string Name) : IRequest<BaseResult<object>>;
}
