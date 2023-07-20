using MediatR;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Queries.File.GetFiles
{
    public class GetFilesQueryRequest : IRequest<Response<GetFilesQueryResponse>>
    {
    }
}
