using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.ServiceCommands
{
    public record RemoveServiceCommand(int Id) : IRequest<BaseResult<object>>;
}
