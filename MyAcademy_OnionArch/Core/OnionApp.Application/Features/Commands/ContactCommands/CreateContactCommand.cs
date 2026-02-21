using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.ContactCommands
{
    public record CreateContactCommand(string Name, string Email, string Subject, string Message) : IRequest<BaseResult<object>>;
}
