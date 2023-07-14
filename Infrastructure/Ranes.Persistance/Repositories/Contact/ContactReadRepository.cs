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
    public class ContactReadRepository : ReadRepository<Domain.Entities.Contact>, IContactReadRepository
    {
        public ContactReadRepository(RanesDbContext context) : base(context)
        {
        }
    }
}
