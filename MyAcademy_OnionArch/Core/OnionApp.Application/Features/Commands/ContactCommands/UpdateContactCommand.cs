using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.ContactCommands
{
    public record UpdateContactCommand(int ContactID, string Name, string Email, string Subject, string Message) : IRequest<BaseResult<object>>;
}
