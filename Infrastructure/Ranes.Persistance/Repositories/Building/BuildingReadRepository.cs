using Microsoft.EntityFrameworkCore;
using Ranes.Application.DTOs.BuildingDto;
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
    public class BuildingReadRepository : ReadRepository<Domain.Entities.Building>, IBuildingReadRepository
    {
        private RanesDbContext _context;
        public BuildingReadRepository(RanesDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BuildingDto>> GetDto()
        {
            var result = await(from b in _context.Buildings
                               join c in _context.Categories on b.CategoryId equals c.Id
                               where b.IsDeleted == false
                               select new BuildingDto
                               {
                                   Id = b.Id,
                                   CategoryName = c.CategoryName,
                                   Title = b.Title,
                                   Description = b.Description,
                                   m2 = b.m2,
                                   CategoryId = b.CategoryId,
                                   Investment = b.Investment,
                                   CompletedProject = b.CompletedProject
                               }).ToListAsync();
            return result;
        }
    }
}
