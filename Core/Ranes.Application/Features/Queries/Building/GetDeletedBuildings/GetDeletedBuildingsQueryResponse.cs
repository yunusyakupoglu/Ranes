using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.Building.GetDeletedBuildings
{
    public class GetDeletedBuildingsQueryResponse
    {
        public IEnumerable<Domain.Entities.Building> Buildings { get; set; }
    }
}
