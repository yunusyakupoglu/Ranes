using FluentValidation.Results;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ranes.Domain.Entities.Responses;

namespace Ranes.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!validators.Any())
            {
                return await next.Invoke();
            }

            var context = new ValidationContext<TRequest>(request);
            var results = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            var failures = results.SelectMany(r => r.Errors).Where(f => f != null).ToList();

            if (!failures.Any())
            {
                return await next.Invoke();
            }

            var response = CreateValidationErrorResponse(failures);
            return await Task.FromResult(response.Data);
        }

        private Response<TResponse> CreateValidationErrorResponse(IEnumerable<ValidationFailure> failures)
        {
            var errors = failures.Select(failure => $"PropertyName: {failure.PropertyName} , ErrorMessage: {failure.ErrorMessage}").ToList();
            return Response<TResponse>.Fail(errors, System.Net.HttpStatusCode.BadRequest);
        }
    }
}
