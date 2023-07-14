using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.Category.GetDeletedCategories
{
    public class GetDeletedCategoriesQueryResponse
    {
        public IEnumerable<Domain.Entities.Category> Categories { get; set; }

    }
}
