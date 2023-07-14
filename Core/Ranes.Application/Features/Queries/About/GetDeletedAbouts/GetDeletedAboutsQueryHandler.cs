using MediatR;
using Ranes.Application.Features.Queries.About.GetAbouts;
using Ranes.Application.Repositories.About;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.About.GetDeletedAbouts
{
    public class GetDeletedAboutsQueryHandler : IRequestHandler<GetDeletedAboutsQueryRequest, Response<GetDeletedAboutsQueryResponse>>
    {

        private readonly IAboutReadRepository _readRepository;

        public GetDeletedAboutsQueryHandler(IAboutReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<Response<GetDeletedAboutsQueryResponse>> Handle(GetDeletedAboutsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _readRepository.GetAllAsync(b => b.IsDeleted == true, false);
            var result = new GetDeletedAboutsQueryResponse();
            result.Abouts = data;
            return Response<GetDeletedAboutsQueryResponse>.Success(result, HttpStatusCode.OK);
        }
    }
}
