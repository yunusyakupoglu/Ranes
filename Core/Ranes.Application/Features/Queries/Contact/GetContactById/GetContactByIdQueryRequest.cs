using MediatR;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.Contact.GetContactById
{
    public class GetContactByIdQueryRequest : IRequest<Response<GetContactByIdQueryResponse>>
    {
        public Guid Id { get; set; }
    }
}
