using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Commands.BrandCommands;
using OnionApp.Application.Features.Queries.BrandQueries;
using OnionApp.Application.Features.Results.BrandResults;

namespace OnionApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BaseResult<List<GetBrandQueryResult>>>> GetAll()
        {
            var result = await _mediator.Send(new GetBrandQuery());
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResult<GetBrandByIdQueryResult>>> GetById(int id)
        {
            var result = await _mediator.Send(new GetBrandByIdQuery(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBrandCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBrandCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new RemoveBrandCommand(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
    }
}
