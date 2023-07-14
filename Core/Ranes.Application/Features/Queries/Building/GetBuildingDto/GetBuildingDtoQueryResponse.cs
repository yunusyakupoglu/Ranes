using Ranes.Application.DTOs.BuildingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.Building.GetBuildingDto
{
    public class GetBuildingDtoQueryResponse
    {
        public IEnumerable<BuildingDto> Dtos { get; set; }
    }
}
