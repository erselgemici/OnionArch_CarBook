using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Features.Queries.BlogQueries;
using OnionApp.Application.Features.Commands.BlogCommands;
using System.Threading.Tasks;

namespace OnionApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetBlogQuery());
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetBlogByIdQuery(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBlogCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new RemoveBlogCommand(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetLast3BlogsWithAuthors")]
        public async Task<IActionResult> GetLast3BlogsWithAuthors()
        {
            
            var result = await _mediator.Send(new GetLast3BlogsWithAuthorsQuery());
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
    }
}
