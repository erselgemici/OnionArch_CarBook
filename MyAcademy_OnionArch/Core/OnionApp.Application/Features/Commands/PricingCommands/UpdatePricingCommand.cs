using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.PricingCommands
{
    public record UpdatePricingCommand(int PricingID, string Name) : IRequest<BaseResult<object>>;
}
