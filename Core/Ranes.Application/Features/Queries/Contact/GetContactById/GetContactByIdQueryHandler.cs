using MediatR;
using Ranes.Application.Repositories.Contact;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.Contact.GetContactById
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQueryRequest, Response<GetContactByIdQueryResponse>>
    {
        private readonly IContactReadRepository _readRepository;

        public GetContactByIdQueryHandler(IContactReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<Response<GetContactByIdQueryResponse>> Handle(GetContactByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _readRepository.GetSingleAsync(x => x.Id == request.Id);
            if (data == null) return Response<GetContactByIdQueryResponse>.Fail("Contact is not exist.", HttpStatusCode.NotFound);
            var result = new GetContactByIdQueryResponse { Contact = data };
            return Response<GetContactByIdQueryResponse>.Success(result, HttpStatusCode.OK);
        }
    }
}
