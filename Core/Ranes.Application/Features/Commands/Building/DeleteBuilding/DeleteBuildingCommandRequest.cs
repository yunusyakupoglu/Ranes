using MediatR;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Commands.Building.DeleteBuilding
{
    public class DeleteBuildingCommandRequest : IRequest<Response<DeleteBuildingCommandResponse>>
    {
        public Guid Id { get; set; }
    }
}
