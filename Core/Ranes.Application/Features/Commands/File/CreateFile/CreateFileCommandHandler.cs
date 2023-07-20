using MediatR;
using Ranes.Application.Abstractions.Services.File;
using Ranes.Application.Repositories.File;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Commands.File.CreateFile
{
    public class CreateFileCommandHandler : IRequestHandler<CreateFileCommandRequest, Response<CreateFileCommandResponse>>
    {
        private readonly IFileReadRepository _readRepository;
        private readonly IFileWriteRepository _writeRepository;
        private readonly IFileService _fileService;
        public CreateFileCommandHandler(IFileReadRepository readRepository, IFileWriteRepository writeRepository, IFileService fileService)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _fileService = fileService;
        }

        public async Task<Response<CreateFileCommandResponse>> Handle(CreateFileCommandRequest request, CancellationToken cancellationToken)
        {
            var addedFiles = new List<Domain.Entities.File>();

            if (request.Files == null || !request.Files.Any())
            {
                return Response<CreateFileCommandResponse>.Fail("No files to upload.", HttpStatusCode.BadRequest);
            }

            var fileNames = await _fileService.UploadFiles(request.Files);

            foreach (var fileName in fileNames)
            {
                var addedFile = new Domain.Entities.File
                {
                    Id = Guid.NewGuid(),
                    CreatedBy = request.CreatedBy,
                    IsDeleted = false,
                    FileName = fileName,
                    BuildingId = request.BuildingId,
                    IsPrimary = false
                };

                addedFiles.Add(addedFile);
                await _writeRepository.AddAsync(addedFile);
            }

            int status = await _writeRepository.SaveAsync();

            if (status == addedFiles.Count)
            {
                return Response<CreateFileCommandResponse>.Success(new CreateFileCommandResponse { Message = "Files added successfully" }, HttpStatusCode.Created);
            }

            return Response<CreateFileCommandResponse>.Fail("Failed to add files. Please try again.", HttpStatusCode.BadRequest);
        }
    }
}
