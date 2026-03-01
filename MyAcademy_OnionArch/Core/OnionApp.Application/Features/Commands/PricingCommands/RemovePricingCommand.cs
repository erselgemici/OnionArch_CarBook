using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.PricingCommands
{
    public record RemovePricingCommand(int Id) : IRequest<BaseResult<object>>;
}
