using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ranes.API.CustomAttributes;
using Ranes.Application.Features.Commands.Building.CreateBuilding;
using Ranes.Application.Features.Commands.Building.DeleteBuilding;
using Ranes.Application.Features.Commands.Building.UpdateBuilding;
using Ranes.Application.Features.Queries.Building.GetBuildingById;
using Ranes.Application.Features.Queries.Building.GetBuildingDto;
using Ranes.Application.Features.Queries.Building.GetBuildings;
using Ranes.Application.Features.Queries.Building.GetDeletedBuildings;
using Ranes.Domain.Entities.Common.Enums.AuthenticationEnums;

namespace Ranes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : BaseApiController
    {
        private readonly IMediator _mediator;

        public BuildingController(IMediator mediator)
        {
            Type controllerType = typeof(BuildingController);
            _mediator = mediator;
        }

        [Auth(PageName.Building)]
        [HttpGet("getall")]
        public async Task<IActionResult> GetList()
        {
            var result = await _mediator.Send(new GetBuildingsQueryRequest());
            return CreateActionResultInstance(result);
        }

        [Auth(PageName.Building)]
        [HttpGet("getalldto")]
        public async Task<IActionResult> GetDtoList()
        {
            var result = await _mediator.Send(new GetBuildingDtoQueryRequest());
            return CreateActionResultInstance(result);
        }

        [Auth(PageName.Building)]
        [HttpGet("getalldeleteds")]
        public async Task<IActionResult> GetDeletedList()
        {
            var result = await _mediator.Send(new GetDeletedBuildingsQueryRequest());
            return CreateActionResultInstance(result);
        }

        [Auth(PageName.Building)]
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var result = await _mediator.Send(new GetBuildingByIdQueryRequest { Id = Id });
            return CreateActionResultInstance(result);
        }

        [Auth(PageName.Building)]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateBuildingCommandRequest createBuilding)
        {
            var result = await _mediator.Send(createBuilding);
            return CreateActionResultInstance(result);
        }

        [Auth(PageName.Building)]
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateBuildingCommandRequest updateBuilding)
        {
            var result = await _mediator.Send(updateBuilding);
            return CreateActionResultInstance(result);
        }

        [Auth(PageName.Building)]
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteBuildingCommandRequest deleteBuilding)
        {
            var result = await _mediator.Send(deleteBuilding);
            return CreateActionResultInstance(result);
        }
    }
}
