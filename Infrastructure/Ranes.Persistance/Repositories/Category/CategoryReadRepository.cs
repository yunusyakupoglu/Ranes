using Ranes.Application.Repositories.Category;
using Ranes.Persistance.Contexts;
using Ranes.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Persistance.Repositories.Category
{
    public class CategoryReadRepository : ReadRepository<Domain.Entities.Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(RanesDbContext context) : base(context)
        {
        }
    }
}
