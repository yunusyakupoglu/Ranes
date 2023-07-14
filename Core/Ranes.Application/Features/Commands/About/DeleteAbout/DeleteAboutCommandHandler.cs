using MediatR;
using Ranes.Application.Features.Commands.Building.DeleteBuilding;
using Ranes.Application.Repositories.About;
using Ranes.Application.Repositories.Building;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Commands.About.DeleteAbout
{
    public class DeleteAboutCommandHandler : IRequestHandler<DeleteAboutCommandRequest, Response<DeleteAboutCommandResponse>>
    {
        private readonly IAboutReadRepository _readRepository;
        private readonly IAboutWriteRepository _writeRepository;

        public DeleteAboutCommandHandler(IAboutReadRepository readRepository, IAboutWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<Response<DeleteAboutCommandResponse>> Handle(DeleteAboutCommandRequest request, CancellationToken cancellationToken)
        {
            var aboutToDelete = await _readRepository.GetSingleAsync(b => b.Id == request.Id);
            if (aboutToDelete == null) return Response<DeleteAboutCommandResponse>.Fail("About is not exist", HttpStatusCode.NotFound);

            aboutToDelete.IsDeleted = true;
            _writeRepository.Update(aboutToDelete);
            await _writeRepository.SaveAsync();
            return Response<DeleteAboutCommandResponse>.Success(HttpStatusCode.OK);
        }
    }
}
