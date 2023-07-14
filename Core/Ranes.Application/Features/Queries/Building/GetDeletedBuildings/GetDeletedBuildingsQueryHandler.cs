using MediatR;
using Ranes.Application.Features.Queries.Building.GetBuildings;
using Ranes.Application.Repositories.Building;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.Building.GetDeletedBuildings
{
    public class GetDeletedBuildingsQueryHandler : IRequestHandler<GetDeletedBuildingsQueryRequest, Response<GetDeletedBuildingsQueryResponse>>
    {

        private readonly IBuildingReadRepository _buildingReadRepository;

        public GetDeletedBuildingsQueryHandler(IBuildingReadRepository buildingReadRepository)
        {
            _buildingReadRepository = buildingReadRepository;
        }

        public async Task<Response<GetDeletedBuildingsQueryResponse>> Handle(GetDeletedBuildingsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _buildingReadRepository.GetAllAsync(b => b.IsDeleted == true, false);
            var result = new GetDeletedBuildingsQueryResponse();
            result.Buildings = data;
            return Response<GetDeletedBuildingsQueryResponse>.Success(result, HttpStatusCode.OK);
        }
    }
}
