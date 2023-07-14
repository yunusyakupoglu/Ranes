using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.Contact.GetContacts
{
    public class GetContactsQueryResponse
    {
        public IEnumerable<Domain.Entities.Contact> Contacts { get; set; }

    }
}
