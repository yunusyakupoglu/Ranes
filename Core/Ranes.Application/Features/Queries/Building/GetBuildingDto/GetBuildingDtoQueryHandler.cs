using MediatR;
using Ranes.Application.Features.Queries.Building.GetBuildingById;
using Ranes.Application.Features.Queries.Building.GetBuildings;
using Ranes.Application.Repositories.Building;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.Building.GetBuildingDto
{
    public class GetBuildingDtoQueryHandler : IRequestHandler<GetBuildingDtoQueryRequest, Response<GetBuildingDtoQueryResponse>>
    {
        private readonly IBuildingReadRepository _buildingReadRepository;

        public GetBuildingDtoQueryHandler(IBuildingReadRepository buildingReadRepository)
        {
            _buildingReadRepository = buildingReadRepository;
        }

        public async Task<Response<GetBuildingDtoQueryResponse>> Handle(GetBuildingDtoQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _buildingReadRepository.GetDto();
            var result = new GetBuildingDtoQueryResponse();
            result.Dtos = data;
            return Response<GetBuildingDtoQueryResponse>.Success(result, HttpStatusCode.OK);
        }
    }
}
