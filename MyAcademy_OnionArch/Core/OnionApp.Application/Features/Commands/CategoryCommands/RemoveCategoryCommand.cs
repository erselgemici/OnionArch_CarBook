using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.CategoryCommands
{
    public class RemoveCategoryCommand(int id) : IRequest<BaseResult<object>>
    {
        public int Id { get; set; } = id;
    }
}
