using MediatR;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Commands.Category.DeleteCategory
{
    public class DeleteCategoryCommandRequest : IRequest<Response<DeleteCategoryCommandResponse>>
    {
        public Guid Id { get; set; }
    }
}
