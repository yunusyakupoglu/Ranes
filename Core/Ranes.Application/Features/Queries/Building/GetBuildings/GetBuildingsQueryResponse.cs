using Ranes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.Building.GetBuildings
{
    public class GetBuildingsQueryResponse
    {
        public IEnumerable<Domain.Entities.Building> Buildings { get; set; }
    }
}
