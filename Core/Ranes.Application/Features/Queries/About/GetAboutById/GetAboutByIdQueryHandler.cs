using MediatR;
using Ranes.Application.Features.Queries.Contact.GetContactById;
using Ranes.Application.Repositories.About;
using Ranes.Application.Repositories.Contact;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.About.GetAboutById
{
    public class GetAboutByIdQueryHandler : IRequestHandler<GetAboutByIdQueryRequest, Response<GetAboutByIdQueryResponse>>
    {
        private readonly IAboutReadRepository _readRepository;

        public GetAboutByIdQueryHandler(IAboutReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<Response<GetAboutByIdQueryResponse>> Handle(GetAboutByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _readRepository.GetSingleAsync(x => x.Id == request.Id);
            if (data == null) return Response<GetAboutByIdQueryResponse>.Fail("About is not exist.", HttpStatusCode.NotFound);
            var result = new GetAboutByIdQueryResponse { About = data };
            return Response<GetAboutByIdQueryResponse>.Success(result, HttpStatusCode.OK);
        }
    }
}
