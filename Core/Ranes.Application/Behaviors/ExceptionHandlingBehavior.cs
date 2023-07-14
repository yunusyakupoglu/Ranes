using Ranes.Domain.Entities.Responses;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ranes.Application.Behaviors
{
    public class ExceptionHandlingBehavior<TRequest, TResponse, TException> : IRequestExceptionHandler<TRequest, TResponse, TException>
        where TRequest : notnull
        where TException : Exception
        where TResponse : notnull
    {
        private readonly ILogger<ExceptionHandlingBehavior<TRequest, TResponse, TException>> logger;

        public ExceptionHandlingBehavior(
            ILogger<ExceptionHandlingBehavior<TRequest, TResponse, TException>> logger)
        {
            this.logger = logger;
        }

        public Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state, CancellationToken cancellationToken)
        {
            var error = CreateExceptionError(exception);

            logger.LogError(JsonSerializer.Serialize(error));

            var response = CreateExceptionError(exception);

            state.SetHandled(response.Data);

            return Task.FromResult(response);
        }

        private static Response<TResponse> CreateExceptionError(TException exception)
        {
            var methodName = exception.TargetSite?.DeclaringType?.DeclaringType?.FullName;
            var message = exception.Message;
            var innerException = exception.InnerException?.Message;
            var stackTrace = exception.StackTrace;

            return Response<TResponse>.Fail(message, System.Net.HttpStatusCode.InternalServerError);
        }
    }
}
