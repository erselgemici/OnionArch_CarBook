using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Commands.CarCommands;
using OnionApp.Application.Features.Handlers.CarHandlers;
using OnionApp.Application.Features.Queries.CarQueries;
using OnionApp.Application.Features.Results.CarResults;

namespace OnionApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BaseResult<List<GetCarQueryResult>>>> GetAll()
        {
            var result = await _mediator.Send(new GetCarQuery());
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResult<GetCarByIdQueryResult>>> GetById(int id)
        {
            var result = await _mediator.Send(new GetCarByIdQuery(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCarCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new RemoveCarCommand(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetLast5CarsWithBrand")]
        public async Task<IActionResult> GetLast5CarsWithBrand()
        {
            var result = await _mediator.Send(new GetLast5CarsWithBrandQuery());

            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
    }
}
