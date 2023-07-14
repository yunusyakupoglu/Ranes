using MediatR;
using Ranes.Application.Repositories.Building;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.Building.GetBuildings
{
    public class GetBuildingsQueryHandler : IRequestHandler<GetBuildingsQueryRequest, Response<GetBuildingsQueryResponse>>
    {

        private readonly IBuildingReadRepository _buildingReadRepository;

        public GetBuildingsQueryHandler(IBuildingReadRepository buildingReadRepository)
        {
            _buildingReadRepository = buildingReadRepository;
        }

        public async Task<Response<GetBuildingsQueryResponse>> Handle(GetBuildingsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _buildingReadRepository.GetAllAsync(b => b.IsDeleted == false, false);
            var result = new GetBuildingsQueryResponse();
            result.Buildings = data;
            return Response<GetBuildingsQueryResponse>.Success(result,HttpStatusCode.OK);
        }
    }
}