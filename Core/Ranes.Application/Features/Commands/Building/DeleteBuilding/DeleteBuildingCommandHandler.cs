using MediatR;
using Ranes.Application.Repositories.Building;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Commands.Building.DeleteBuilding
{
    public class DeleteBuildingCommandHandler : IRequestHandler<DeleteBuildingCommandRequest, Response<DeleteBuildingCommandResponse>>
    {
        private readonly IBuildingReadRepository _buildingReadRepository;
        private readonly IBuildingWriteRepository _buildingWriteRepository;

        public DeleteBuildingCommandHandler(IBuildingReadRepository buildingReadRepository, IBuildingWriteRepository buildingWriteRepository)
        {
            _buildingReadRepository = buildingReadRepository;
            _buildingWriteRepository = buildingWriteRepository;
        }

        public async Task<Response<DeleteBuildingCommandResponse>> Handle(DeleteBuildingCommandRequest request, CancellationToken cancellationToken)
        {
            var buildingToDelete = await _buildingReadRepository.GetSingleAsync(b => b.Id == request.Id);
            if (buildingToDelete == null) return Response<DeleteBuildingCommandResponse>.Fail("Building is not exist", HttpStatusCode.NotFound);

            buildingToDelete.IsDeleted = true;
            _buildingWriteRepository.Update(buildingToDelete);
            await _buildingWriteRepository.SaveAsync();
            return Response<DeleteBuildingCommandResponse>.Success(HttpStatusCode.OK);
        }
    }
}
