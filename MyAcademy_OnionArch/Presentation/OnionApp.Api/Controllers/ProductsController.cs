using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Features.Commands.ProductCommands;
using OnionApp.Application.Features.Queries.ProductQueries;
using OnionApp.Application.Features.Results.ProductResults;
using System.Threading.Tasks;

namespace OnionApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            var result = await _mediator.Send(command);

            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<GetProductsQueryResult>>> GetAll()
        {
            var result = await _mediator.Send(new GetProductsQuery());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<GetProductsQueryResult>>> GetById(int id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery(id));

            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommand command)
        {
            var result = await _mediator.Send(command);

            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> actionResult(int id)
        {
            var result = await _mediator.Send(new RemoveProductCommand(id));

            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
    }
}
