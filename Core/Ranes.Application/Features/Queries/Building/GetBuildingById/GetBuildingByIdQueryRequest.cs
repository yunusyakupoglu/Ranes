using MediatR;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.Building.GetBuildingById
{
    public class GetBuildingByIdQueryRequest : IRequest<Response<GetBuildingByIdQueryResponse>>
    {
        public Guid Id { get; set; }
    }
}
