using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.Contact.GetDeletedContacts
{
    public class GetDeletedContactsQueryResponse
    {
        public IEnumerable<Domain.Entities.Contact> Contacts { get; set; }

    }
}
