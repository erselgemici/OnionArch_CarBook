using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.ContactCommands
{
    public record RemoveContactCommand(int Id) : IRequest<BaseResult<object>>;
}
