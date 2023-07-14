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
            FileModel files = new FileModel
            {
                ImgPrimary = request.ImgPrimary,
                ImgOne = request.ImgOne,
                ImgTwo = request.ImgTwo,
                ImgThree = request.ImgThree,
                ImgFour = request.ImgFour,
                ImgFive = request.ImgFive,
                ImgSix = request.ImgSix,
                ImgSeven = request.ImgSeven,
                ImgEight = request.ImgEight,
                ImgNine = request.ImgNine,
                ImgTen = request.ImgTen
            };

            var fileNames = await _fileService.Upload(files);

            var isThereBuildingRecord = await _readRepository.GetSingleAsync(x => x.Id == request.Id);
            isThereBuildingRecord.UpdatedBy = request.UpdatedBy;
            isThereBuildingRecord.UpdatedDate = DateTime.UtcNow;
            isThereBuildingRecord.Title = request.Title;
            isThereBuildingRecord.Description = request.Description;
            isThereBuildingRecord.m2 = request.m2;
            isThereBuildingRecord.ImgPrimary = fileNames.ImgPrimaryPath;
            isThereBuildingRecord.ImgOne = fileNames.ImgOnePath;
            isThereBuildingRecord.ImgTwo = fileNames.ImgTwoPath;
            isThereBuildingRecord.ImgThree = fileNames.ImgThreePath;
            isThereBuildingRecord.ImgFour = fileNames.ImgFourPath;
            isThereBuildingRecord.ImgFive = fileNames.ImgFivePath;
            isThereBuildingRecord.ImgSix = fileNames.ImgSixPath;
            isThereBuildingRecord.ImgSeven = fileNames.ImgSevenPath;
            isThereBuildingRecord.ImgEight = fileNames.ImgEightPath;
            isThereBuildingRecord.ImgNine = fileNames.ImgNinePath;
            isThereBuildingRecord.ImgTen = fileNames.ImgTenPath;
            isThereBuildingRecord.CategoryId = request.CategoryId;
            isThereBuildingRecord.Investment = request.Investment;
            isThereBuildingRecord.CompletedProject = request.CompletedProject;

            _writeRepository.Update(isThereBuildingRecord);
            await _writeRepository.SaveAsync();
            return Response<UpdateBuildingCommandResponse>.Success(HttpStatusCode.OK);
            

        }
    }
}
