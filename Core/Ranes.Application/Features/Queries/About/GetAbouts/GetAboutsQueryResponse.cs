using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.About.GetAbouts
{
    public class GetAboutsQueryResponse
    {
        public IEnumerable<Domain.Entities.About> Abouts { get; set; }

    }
}
