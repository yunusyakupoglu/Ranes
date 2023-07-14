using MediatR;
using Ranes.Application.Repositories.Contact;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.Contact.GetContacts
{
    public class GetContactsQueryHandler : IRequestHandler<GetContactsQueryRequest, Response<GetContactsQueryResponse>>
    {

        private readonly IContactReadRepository _readRepository;

        public GetContactsQueryHandler(IContactReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<Response<GetContactsQueryResponse>> Handle(GetContactsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _readRepository.GetAllAsync(b => b.IsDeleted == false, false);
            var result = new GetContactsQueryResponse();
            result.Contacts = data;
            return Response<GetContactsQueryResponse>.Success(result, HttpStatusCode.OK);
        }
    }
}
