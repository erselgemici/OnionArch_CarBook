using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.FeatureCommands
{
    public record RemoveFeatureCommand(int Id) : IRequest<BaseResult<object>>;
}
