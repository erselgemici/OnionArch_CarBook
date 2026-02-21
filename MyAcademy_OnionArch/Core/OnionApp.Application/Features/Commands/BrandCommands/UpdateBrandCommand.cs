using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.BrandCommands
{
    public record UpdateBrandCommand(int BrandID, string Name) : IRequest<BaseResult<object>>;
}
