using MediatR;
using Ranes.Application.Repositories.Building;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.Building.GetBuildingById
{
    public class GetBuildingByIdQueryHandler : IRequestHandler<GetBuildingByIdQueryRequest, Response<GetBuildingByIdQueryResponse>>
    {
        private readonly IBuildingReadRepository _buildingReadRepository;

        public GetBuildingByIdQueryHandler(IBuildingReadRepository buildingReadRepository)
        {
            _buildingReadRepository = buildingReadRepository;
        }

        public async Task<Response<GetBuildingByIdQueryResponse>> Handle(GetBuildingByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _buildingReadRepository.GetSingleAsync(x=>x.Id == request.Id);
            if (data == null) return Response<GetBuildingByIdQueryResponse>.Fail("Building is not exist.", HttpStatusCode.NotFound);
            var result = new GetBuildingByIdQueryResponse { Building = data };
            return Response<GetBuildingByIdQueryResponse>.Success(result, HttpStatusCode.OK);
        }
    }
}
