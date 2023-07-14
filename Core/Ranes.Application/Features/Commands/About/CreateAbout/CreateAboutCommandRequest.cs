using MediatR;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Commands.About.CreateAbout
{
    public class CreateAboutCommandRequest : IRequest<Response<CreateAboutCommandResponse>>
    {
        public string CreatedBy { get; set; }
        public string AboutUs { get; set; }
        public string OurHistory { get; set; }
        public string OurVision { get; set; }
        public string OurMission { get; set; }
    }
}
