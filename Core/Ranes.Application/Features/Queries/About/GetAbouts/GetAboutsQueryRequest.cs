using MediatR;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.About.GetAbouts
{
    public class GetAboutsQueryRequest : IRequest<Response<GetAboutsQueryResponse>>
    {
    }
}
