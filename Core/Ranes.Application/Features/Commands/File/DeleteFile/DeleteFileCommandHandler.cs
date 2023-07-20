using MediatR;
using Ranes.Application.Abstractions.Services.File;
using Ranes.Application.Features.Commands.Building.DeleteBuilding;
using Ranes.Application.Features.Commands.File.UpdateFile;
using Ranes.Application.Repositories.File;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Commands.File.DeleteFile
{
    public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommandRequest, Response<DeleteFileCommandResponse>>
    {
        private readonly IFileReadRepository _readRepository;
        private readonly IFileWriteRepository _writeRepository;
        private readonly IFileService _fileService;

        public DeleteFileCommandHandler(IFileReadRepository readRepository, IFileWriteRepository writeRepository, IFileService fileService)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _fileService = fileService;
        }

        public async Task<Response<DeleteFileCommandResponse>> Handle(DeleteFileCommandRequest request, CancellationToken cancellationToken)
        {
            var fileToDelete = await _readRepository.GetSingleAsync(x => x.Id == request.Id);
            if (fileToDelete == null) return Response<DeleteFileCommandResponse>.Fail("File is not exist", HttpStatusCode.NotFound);

            var status = await _fileService.DeleteFile(fileToDelete.FileName);

            if (status == 1)
            {
            _writeRepository.Remove(fileToDelete);
            await _writeRepository.SaveAsync();
            return Response<DeleteFileCommandResponse>.Success(HttpStatusCode.OK);
            }
            return Response<DeleteFileCommandResponse>.Fail("Failed to delete file.", HttpStatusCode.BadRequest);

        }
    }
}
