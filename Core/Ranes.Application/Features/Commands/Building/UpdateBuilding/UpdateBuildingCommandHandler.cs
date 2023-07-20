using MediatR;
using Ranes.Application.Abstractions.Services.File;
using Ranes.Application.DTOs.File;
using Ranes.Application.Repositories.Building;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Commands.Building.UpdateBuilding
{
    public class UpdateBuildingCommandHandler : IRequestHandler<UpdateBuildingCommandRequest, Response<UpdateBuildingCommandResponse>>
    {
        private readonly IBuildingReadRepository _readRepository;
        private readonly IBuildingWriteRepository _writeRepository;
        private readonly IFileService _fileService;

        public UpdateBuildingCommandHandler(IBuildingReadRepository readRepository, IBuildingWriteRepository writeRepository, IFileService fileService)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _fileService = fileService;
        }

        public async Task<Response<UpdateBuildingCommandResponse>> Handle(UpdateBuildingCommandRequest request, CancellationToken cancellationToken)
        {
            var isThereBuildingRecord = await _readRepository.GetSingleAsync(x => x.Id == request.Id);
            isThereBuildingRecord.UpdatedBy = request.UpdatedBy;
            isThereBuildingRecord.UpdatedDate = DateTime.UtcNow;
            isThereBuildingRecord.Title = request.Title;
            isThereBuildingRecord.Description = request.Description;
            isThereBuildingRecord.m2 = request.m2;
            isThereBuildingRecord.CategoryId = request.CategoryId;
            isThereBuildingRecord.Investment = request.Investment;
            isThereBuildingRecord.CompletedProject = request.CompletedProject;

            _writeRepository.Update(isThereBuildingRecord);
            await _writeRepository.SaveAsync();
            return Response<UpdateBuildingCommandResponse>.Success(HttpStatusCode.OK);
            

        }
    }
}
