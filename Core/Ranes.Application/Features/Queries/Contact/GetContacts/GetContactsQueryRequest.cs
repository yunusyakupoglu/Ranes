using MediatR;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.Contact.GetContacts
{
    public class GetContactsQueryRequest : IRequest<Response<GetContactsQueryResponse>>
    {
    }
}
