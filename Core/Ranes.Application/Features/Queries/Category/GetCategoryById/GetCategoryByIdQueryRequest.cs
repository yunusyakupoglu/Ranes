using MediatR;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.Category.GetCategoryById
{
    public class GetCategoryByIdQueryRequest : IRequest<Response<GetCategoryByIdQueryResponse>>
    {
        public Guid Id { get; set; }
    }
}
