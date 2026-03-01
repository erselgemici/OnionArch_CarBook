using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.LocationCommands
{
    public record RemoveLocationCommand(int Id) : IRequest<BaseResult<object>>;
}
