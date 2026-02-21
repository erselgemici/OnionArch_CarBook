using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Commands.BannerCommands;
using OnionApp.Application.Features.Queries.BannerQueries;
using OnionApp.Application.Features.Results.BannerResults;

namespace OnionApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BaseResult<List<GetBannerQueryResult>>>> GetAll()
        {
            var result = await _mediator.Send(new GetBannerQuery());
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResult<GetBannerByIdQueryResult>>> GetById(int id)
        {
            var result = await _mediator.Send(new GetBannerByIdQuery(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBannerCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBannerCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new RemoveBannerCommand(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
    }
}
