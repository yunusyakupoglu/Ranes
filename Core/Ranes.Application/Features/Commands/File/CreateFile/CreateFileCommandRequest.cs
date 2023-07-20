using MediatR;
using Microsoft.AspNetCore.Http;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Commands.File.CreateFile
{
    public class CreateFileCommandRequest : IRequest<Response<CreateFileCommandResponse>>
    {
        public string CreatedBy { get; set; }
        public List<IFormFile> Files { get; set; }
        public Guid BuildingId { get; set; }

    }
}
