using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.CategoryCommands
{
    public class CreateCategoryCommand : IRequest<BaseResult<object>>
    {
        public string? Name { get; set; }
    }
}
