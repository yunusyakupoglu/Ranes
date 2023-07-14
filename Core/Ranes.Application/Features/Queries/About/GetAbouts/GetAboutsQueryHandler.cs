using MediatR;
using Ranes.Application.Repositories.About;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.About.GetAbouts
{
    public class GetAboutsQueryHandler : IRequestHandler<GetAboutsQueryRequest, Response<GetAboutsQueryResponse>>
    {

        private readonly IAboutReadRepository _readRepository;

        public GetAboutsQueryHandler(IAboutReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<Response<GetAboutsQueryResponse>> Handle(GetAboutsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _readRepository.GetAllAsync(b => b.IsDeleted == false, false);
            var result = new GetAboutsQueryResponse();
            result.Abouts = data;
            return Response<GetAboutsQueryResponse>.Success(result, HttpStatusCode.OK);
        }
    }
}
