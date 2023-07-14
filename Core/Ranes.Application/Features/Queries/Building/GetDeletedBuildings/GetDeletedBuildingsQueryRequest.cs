using MediatR;
using Ranes.Application.Features.Queries.Building.GetBuildings;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.Building.GetDeletedBuildings
{
    public class GetDeletedBuildingsQueryRequest : IRequest<Response<GetDeletedBuildingsQueryResponse>>
    {
    }
}
