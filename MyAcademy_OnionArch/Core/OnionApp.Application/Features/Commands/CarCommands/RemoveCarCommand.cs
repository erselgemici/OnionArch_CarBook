using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.CarCommands
{
    public record RemoveCarCommand(int Id) : IRequest<BaseResult<object>>;
}
