using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.AboutCommands
{
    public class CreateAboutCommand : IRequest<BaseResult<object>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
