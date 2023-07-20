using MediatR;
using Microsoft.AspNetCore.Http;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Commands.Building.CreateBuilding
{
    public class CreateBuildingCommandRequest : IRequest<Response<CreateBuildingCommandResponse>>
    {
        public string CreatedBy { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float m2 { get; set; }
        public Guid CategoryId { get; set; }
        public bool Investment { get; set; }
        public bool CompletedProject { get; set; }

    }
}
