using MediatR;
using Ranes.Application.Features.Queries.Contact.GetContacts;
using Ranes.Application.Repositories.Contact;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.Contact.GetDeletedContacts
{
    public class GetDeletedContactsQueryHandler : IRequestHandler<GetDeletedContactsQueryRequest, Response<GetDeletedContactsQueryResponse>>
    {

        private readonly IContactReadRepository _readRepository;

        public GetDeletedContactsQueryHandler(IContactReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<Response<GetDeletedContactsQueryResponse>> Handle(GetDeletedContactsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _readRepository.GetAllAsync(b => b.IsDeleted == true, false);
            var result = new GetDeletedContactsQueryResponse();
            result.Contacts = data;
            return Response<GetDeletedContactsQueryResponse>.Success(result, HttpStatusCode.OK);
        }
    }
}
