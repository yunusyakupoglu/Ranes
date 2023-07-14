using MediatR;
using Microsoft.AspNetCore.Http;
using Ranes.Application.Abstractions.Services.File;
using Ranes.Application.DTOs.File;
using Ranes.Application.Repositories.Building;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Commands.Building.CreateBuilding
{
    public class CreateBuildingCommandHandler : IRequestHandler<CreateBuildingCommandRequest, Response<CreateBuildingCommandResponse>>
    {
        private readonly IBuildingReadRepository _readRepository;
        private readonly IBuildingWriteRepository _writeRepository;
        private readonly IFileService _fileService;

        public CreateBuildingCommandHandler(IBuildingReadRepository readRepository, IBuildingWriteRepository writeRepository, IFileService fileService)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _fileService = fileService;
        }

        public async Task<Response<CreateBuildingCommandResponse>> Handle(CreateBuildingCommandRequest request, CancellationToken cancellationToken)
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

            var addedBuilding = new Domain.Entities.Building
            {
                Id = Guid.NewGuid(),
                CreatedBy = request.CreatedBy,
                IsDeleted = false,
                CategoryId = request.CategoryId,
                CompletedProject = request.CompletedProject,
                Investment = request.Investment,
                m2 = request.m2,
                Title = request.Title,
                Description = request.Description,
                ImgPrimary = fileNames.ImgPrimaryPath,
                ImgOne = fileNames.ImgOnePath,
                ImgTwo = fileNames.ImgTwoPath,
                ImgThree = fileNames.ImgThreePath,
                ImgFour = fileNames.ImgFourPath,
                ImgFive = fileNames.ImgFivePath,
                ImgSix = fileNames.ImgSixPath,
                ImgSeven = fileNames.ImgSevenPath,
                ImgEight = fileNames.ImgEightPath,
                ImgNine = fileNames.ImgNinePath,
                ImgTen = fileNames.ImgTenPath
            };

            await _writeRepository.AddAsync(addedBuilding);
            int status = await _writeRepository.SaveAsync();

            if (status == 1)
                return Response<CreateBuildingCommandResponse>.Success(new() { Message = "Building added successfully" }, HttpStatusCode.Created);

            return Response<CreateBuildingCommandResponse>.Fail("Failed to add building. Please try again.", HttpStatusCode.BadRequest);
        }
    }
}
