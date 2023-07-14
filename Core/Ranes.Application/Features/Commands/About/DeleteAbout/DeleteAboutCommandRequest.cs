using MediatR;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Commands.About.DeleteAbout
{
    public class DeleteAboutCommandRequest : IRequest<Response<DeleteAboutCommandResponse>>
    {
        public Guid Id { get; set; }
    }
}
