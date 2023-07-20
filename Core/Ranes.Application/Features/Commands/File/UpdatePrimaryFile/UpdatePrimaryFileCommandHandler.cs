using MediatR;
using Ranes.Application.Features.Commands.Category.UpdateCategory;
using Ranes.Application.Repositories.File;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Commands.File.UpdatePrimaryFile
{
    public class UpdatePrimaryFileCommandHandler : IRequestHandler<UpdatePrimaryFileCommandRequest, Response<UpdatePrimaryFileCommandResponse>>
    {
        private readonly IFileReadRepository _readRepository;
        private readonly IFileWriteRepository _writeRepository;

        public UpdatePrimaryFileCommandHandler(IFileReadRepository readRepository, IFileWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<Response<UpdatePrimaryFileCommandResponse>> Handle(UpdatePrimaryFileCommandRequest request, CancellationToken cancellationToken)
        {
            var isTherePrimaryFileRecord = await _readRepository.GetSingleAsync(x => x.Id == request.Id);
            isTherePrimaryFileRecord.UpdatedBy = request.UpdatedBy;
            isTherePrimaryFileRecord.UpdatedDate = DateTime.UtcNow;
            isTherePrimaryFileRecord.IsPrimary = request.IsPrimary;

            _writeRepository.Update(isTherePrimaryFileRecord);
            await _writeRepository.SaveAsync();
            return Response<UpdatePrimaryFileCommandResponse>.Success(HttpStatusCode.OK);
        }
    }
}
