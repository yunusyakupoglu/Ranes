using MediatR;
using Microsoft.AspNetCore.Http;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Commands.File.UpdateFile
{
    public class UpdateFileCommandRequest : IRequest<Response<UpdateFileCommandResponse>>
    {
        public Guid Id { get; set; }
        public string UpdatedBy { get; set; }
        public IFormFile File { get; set; }
        public Guid BuildingId { get; set; }

    }
}
