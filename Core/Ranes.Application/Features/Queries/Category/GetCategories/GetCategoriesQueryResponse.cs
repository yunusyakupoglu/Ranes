using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.Category.GetCategories
{
    public class GetCategoriesQueryResponse
    {
        public IEnumerable<Domain.Entities.Category> Categories { get; set; }

    }
}
