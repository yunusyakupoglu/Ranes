using MediatR;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Commands.Category.UpdateCategory
{
    public class UpdateCategoryCommandRequest : IRequest<Response<UpdateCategoryCommandResponse>>
    {
        public Guid Id { get; set; }
        public string UpdatedBy { get; set; }
        public string CategoryName { get; set; }
    }
}
