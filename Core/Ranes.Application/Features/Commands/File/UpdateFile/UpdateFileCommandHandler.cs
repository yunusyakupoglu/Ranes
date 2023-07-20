using MediatR;
using Ranes.Application.Abstractions.Services.File;
using Ranes.Application.Features.Commands.Building.UpdateBuilding;
using Ranes.Application.Features.Commands.File.CreateFile;
using Ranes.Application.Repositories.File;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Commands.File.UpdateFile
{
    public class UpdateFileCommandHandler : IRequestHandler<UpdateFileCommandRequest, Response<UpdateFileCommandResponse>>
    {
        private readonly IFileReadRepository _readRepository;
        private readonly IFileWriteRepository _writeRepository;
        private readonly IFileService _fileService;

        public UpdateFileCommandHandler(IFileReadRepository readRepository, IFileWriteRepository writeRepository, IFileService fileService)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _fileService = fileService;
        }

        public async Task<Response<UpdateFileCommandResponse>> Handle(UpdateFileCommandRequest request, CancellationToken cancellationToken)
        {
            var deleteStatus = 0;
            var uploadedFilename = await _fileService.UploadFile(request.File);

            var isThereFileRecord = await _readRepository.GetSingleAsync(x => x.Id == request.Id);
            if (uploadedFilename != null || uploadedFilename != string.Empty)
                 deleteStatus = await _fileService.DeleteFile(isThereFileRecord.FileName);

            isThereFileRecord.UpdatedBy = request.UpdatedBy;
            isThereFileRecord.UpdatedDate = DateTime.UtcNow;
            isThereFileRecord.FileName = request.File.FileName;
            isThereFileRecord.BuildingId = request.BuildingId;
            isThereFileRecord.IsDeleted = false;
            

            if (deleteStatus == 1)
            {
                _writeRepository.Update(isThereFileRecord);
                await _writeRepository.SaveAsync();
                return Response<UpdateFileCommandResponse>.Success(HttpStatusCode.OK);
            }
            else
            {
                return Response<UpdateFileCommandResponse>.Fail("Failed to delete file.", HttpStatusCode.BadRequest);
            }
        }
    }
}
