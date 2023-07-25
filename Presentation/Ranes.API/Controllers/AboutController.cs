using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ranes.Application.Features.Commands.About.CreateAbout;
using Ranes.Application.Features.Commands.About.DeleteAbout;
using Ranes.Application.Features.Commands.About.UpdateAbout;
using Ranes.Application.Features.Queries.About.GetAboutById;
using Ranes.Application.Features.Queries.About.GetAbouts;
using Ranes.Application.Features.Queries.About.GetDeletedAbouts;
using Ranes.Domain.Entities.Common.Enums.AuthenticationEnums;

namespace Ranes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : BaseApiController
    {
        private readonly IMediator _mediator;

        public AboutController(IMediator mediator)
        {
            Type controllerType = typeof(AboutController);
            _mediator = mediator;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetList()
        {
            var result = await _mediator.Send(new GetAboutsQueryRequest());
            return CreateActionResultInstance(result);
        }

        [HttpGet("getalldeleteds")]
        public async Task<IActionResult> GetDeletedList()
        {
            var result = await _mediator.Send(new GetDeletedAboutsQueryRequest());
            return CreateActionResultInstance(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var result = await _mediator.Send(new GetAboutByIdQueryRequest { Id = Id });
            return CreateActionResultInstance(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateAboutCommandRequest createAbout)
        {
            var result = await _mediator.Send(createAbout);
            return CreateActionResultInstance(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAboutCommandRequest updateAbout)
        {
            var result = await _mediator.Send(updateAbout);
            return CreateActionResultInstance(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteAboutCommandRequest deleteAbout)
        {
            var result = await _mediator.Send(deleteAbout);
            return CreateActionResultInstance(result);
        }
    }
}
