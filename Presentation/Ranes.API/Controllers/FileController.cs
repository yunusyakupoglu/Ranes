using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ranes.Application.Features.Commands.About.CreateAbout;
using Ranes.Application.Features.Commands.About.DeleteAbout;
using Ranes.Application.Features.Commands.About.UpdateAbout;
using Ranes.Application.Features.Commands.File.CreateFile;
using Ranes.Application.Features.Commands.File.DeleteFile;
using Ranes.Application.Features.Commands.File.UpdateFile;
using Ranes.Application.Features.Commands.File.UpdatePrimaryFile;
using Ranes.Application.Features.Queries.About.GetAboutById;
using Ranes.Application.Features.Queries.About.GetAbouts;
using Ranes.Application.Features.Queries.About.GetDeletedAbouts;
using Ranes.Application.Features.Queries.File.GetFileById;
using Ranes.Application.Features.Queries.File.GetFiles;
using Ranes.Application.Features.Queries.File.GetFilesByBuildingId;

namespace Ranes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : BaseApiController
    {
        private readonly IMediator _mediator;

        public FileController(IMediator mediator)
        {
            Type controllerType = typeof(FileController);
            _mediator = mediator;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetList()
        {
            var result = await _mediator.Send(new GetFilesQueryRequest());
            return CreateActionResultInstance(result);
        }

        [HttpGet("getallbybuildingid")]
        public async Task<IActionResult> GetListByBuildingId(Guid buildingId)
        {
            var result = await _mediator.Send(new GetFilesByBuildingIdQueryRequest { BuildingId = buildingId });
            return CreateActionResultInstance(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var result = await _mediator.Send(new GetFileByIdQueryRequest { Id = Id });
            return CreateActionResultInstance(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateFileCommandRequest createFile)
        {
            var result = await _mediator.Send(createFile);
            return CreateActionResultInstance(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateFileCommandRequest updateFile)
        {
            var result = await _mediator.Send(updateFile);
            return CreateActionResultInstance(result);
        }

        [HttpPut("updateprimaryfile")]
        public async Task<IActionResult> UpdatePrimaryFile(UpdatePrimaryFileCommandRequest updatePrimaryFile)
        {
            var result = await _mediator.Send(updatePrimaryFile);
            return CreateActionResultInstance(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteFileCommandRequest deleteFile)
        {
            var result = await _mediator.Send(deleteFile);
            return CreateActionResultInstance(result);
        }
    }
}
