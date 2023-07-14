using MediatR;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Commands.About.UpdateAbout
{
    public class UpdateAboutCommandRequest : IRequest<Response<UpdateAboutCommandResponse>>
    {
        public Guid Id { get; set; }
        public string UpdatedBy { get; set; }
        public string AboutUs { get; set; }
        public string OurHistory { get; set; }
        public string OurVision { get; set; }
        public string OurMission { get; set; }
    }
}
