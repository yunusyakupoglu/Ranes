using Ranes.Application.Repositories.Building;
using Ranes.Persistance.Contexts;
using Ranes.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Persistance.Repositories.Building
{
    public class BuildingWriteRepository : WriteRepository<Domain.Entities.Building>, IBuildingWriteRepository
    {
        public BuildingWriteRepository(RanesDbContext context) : base(context)
        {
        }
    }
}
