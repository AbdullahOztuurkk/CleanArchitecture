using CleanArch.Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Behaviours
{
    /// <summary>
    /// Logging Middleware for all mediatr request and response objects
    /// </summary>
    /// <typeparam name="TRequest">Any IRequest</typeparam>
    /// <typeparam name="TResponse">Response Object by TRequest</typeparam>
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
       where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;
        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            //Request
            _logger.LogInformation($"Executing {typeof(TRequest).Name} operation...");
            Type myType = request.GetType();

            //Get request values
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            foreach (PropertyInfo prop in props)
            {
                object propValue = prop.GetValue(request, null);
                _logger.LogInformation("{Property} : {@Value}", prop.Name, propValue);
            }

            var response = await next();
            //Response
            _logger.LogInformation($"Response Type : {typeof(TResponse).Name}");
            return response;
        }
    }
}
