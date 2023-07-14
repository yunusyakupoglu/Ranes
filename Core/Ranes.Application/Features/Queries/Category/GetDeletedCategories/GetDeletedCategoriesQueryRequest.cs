using MediatR;
using Ranes.Application.Features.Queries.Category.GetCategories;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.Category.GetDeletedCategories
{
    public class GetDeletedCategoriesQueryRequest : IRequest<Response<GetDeletedCategoriesQueryResponse>>
    {
    }
}
