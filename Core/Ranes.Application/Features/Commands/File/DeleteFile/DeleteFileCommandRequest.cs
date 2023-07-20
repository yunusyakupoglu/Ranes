using MediatR;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Commands.File.DeleteFile
{
    public class DeleteFileCommandRequest : IRequest<Response<DeleteFileCommandResponse>>
    {
        public Guid Id { get; set; }

    }
}
