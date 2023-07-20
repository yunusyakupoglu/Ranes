using MediatR;
using Ranes.Application.Features.Queries.File.GetFiles;
using Ranes.Application.Repositories;
using Ranes.Application.Repositories.File;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.File.GetFilesByBuildingId
{
    public class GetFilesByBuildingIdQueryHandler : IRequestHandler<GetFilesByBuildingIdQueryRequest, Response<GetFilesByBuildingIdQueryResponse>>
    {
        private readonly IFileReadRepository _readRepository;

        public GetFilesByBuildingIdQueryHandler(IFileReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<Response<GetFilesByBuildingIdQueryResponse>> Handle(GetFilesByBuildingIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _readRepository.GetAllAsync(b => b.IsDeleted == false && b.BuildingId == request.BuildingId, false);
            var result = new GetFilesByBuildingIdQueryResponse();
            result.Files = data;
            return Response<GetFilesByBuildingIdQueryResponse>.Success(result, HttpStatusCode.OK);
        }
    }
}
