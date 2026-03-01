using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.PricingCommands
{
    public record CreatePricingCommand(string Name) : IRequest<BaseResult<object>>;
}
