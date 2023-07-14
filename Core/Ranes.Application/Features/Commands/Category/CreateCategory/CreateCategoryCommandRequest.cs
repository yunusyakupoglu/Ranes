using MediatR;
using Ranes.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Features.Commands.Category.CreateCategory
{
    public class CreateCategoryCommandRequest : IRequest<Response<CreateCategoryCommandResponse>>
    {
        public string CreatedBy { get; set; }
        public string CategoryName { get; set; }
    }
}
