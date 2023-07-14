using Ranes.Application.DTOs.BuildingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Repositories.Building
{
    public interface IBuildingReadRepository : IReadRepository<Domain.Entities.Building>
    {
        Task<IEnumerable<BuildingDto>> GetDto();
    }
}
