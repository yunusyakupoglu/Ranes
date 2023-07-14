using FluentValidation;
using Ranes.Application.Features.Commands.Building.DeleteBuilding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Validations.Building.DeleteBuilding
{
    public class DeleteBuildingCommandRequestValidator : AbstractValidator<DeleteBuildingCommandRequest>
    {
        public DeleteBuildingCommandRequestValidator()
        {
            RuleFor(request => request.Id)
    .NotEmpty().WithMessage("Id cannot be empty.")
    .NotEqual(Guid.Empty).WithMessage("Please specify a valid Id.");
        }
    }
}
