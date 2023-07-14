using Ranes.Application.Repositories.Contact;
using Ranes.Persistance.Contexts;
using Ranes.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Persistance.Repositories.Contact
{
    public class ContactWriteRepository : WriteRepository<Domain.Entities.Contact>, IContactWriteRepository
    {
        public ContactWriteRepository(RanesDbContext context) : base(context)
        {
        }
    }
}
