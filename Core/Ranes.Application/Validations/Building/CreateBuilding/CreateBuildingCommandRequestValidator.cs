using FluentValidation;
using Ranes.Application.Features.Commands.Building.CreateBuilding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Validations.Building.CreateBuilding
{
    public class CreateBuildingCommandRequestValidator : AbstractValidator<CreateBuildingCommandRequest>
    {
        public CreateBuildingCommandRequestValidator()
        {
            RuleFor(request => request.Title).NotEmpty().WithMessage("Title cannot be empty.");
        }
    }
}
