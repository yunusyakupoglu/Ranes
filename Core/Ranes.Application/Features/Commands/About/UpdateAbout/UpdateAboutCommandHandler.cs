using MediatR;
using Ranes.Application.Features.Commands.Category.UpdateCategory;
using Ranes.Application.Repositories.About;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Commands.About.UpdateAbout
{
    public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommandRequest, Response<UpdateAboutCommandResponse>>
    {
        private readonly IAboutReadRepository _readRepository;
        private readonly IAboutWriteRepository _writeRepository;

        public UpdateAboutCommandHandler(IAboutReadRepository readRepository, IAboutWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<Response<UpdateAboutCommandResponse>> Handle(UpdateAboutCommandRequest request, CancellationToken cancellationToken)
        {
            var isThereAboutRecord = await _readRepository.GetSingleAsync(x => x.Id == request.Id);
            isThereAboutRecord.UpdatedBy = request.UpdatedBy;
            isThereAboutRecord.UpdatedDate = DateTime.UtcNow;
            isThereAboutRecord.AboutUs = request.AboutUs;
            isThereAboutRecord.OurHistory = request.OurHistory;
            isThereAboutRecord.OurVision = request.OurVision;
            isThereAboutRecord.OurMission = request.OurMission;

            _writeRepository.Update(isThereAboutRecord);
            await _writeRepository.SaveAsync();
            return Response<UpdateAboutCommandResponse>.Success(HttpStatusCode.OK);
        }
    }
}
