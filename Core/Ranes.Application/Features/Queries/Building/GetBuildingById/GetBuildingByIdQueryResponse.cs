using Ranes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.Building.GetBuildingById
{
    public class GetBuildingByIdQueryResponse
    {
        public Domain.Entities.Building Building { get; set; }
    }
}
