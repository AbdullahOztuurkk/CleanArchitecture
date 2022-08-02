using CleanArch.Domain.Common;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;


//namespace CleanArch.Application.Behaviours
//{
//    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
//    {
//        private readonly IEnumerable<IValidator<TRequest>> _validators;

//        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
//        {
//            _validators = validators;
//        }

//        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
//        {
//            if (_validators.Any())
//            {
//                var context = new ValidationContext<TRequest>(request);

//                var validationResults = await Task.WhenAll(
//                    _validators.Select(v =>
//                        v.ValidateAsync(context, cancellationToken)));

//                var failures = validationResults
//                    .Where(r => r.Errors.Any())
//                    .SelectMany(r => r.Errors)
//                    .ToList();

//                if (failures.Any())
//                    throw new ValidationException(failures);
//            }
//            return await next();
//        }
//    }

//}


namespace CleanArch.Application.Behaviours
{
    /// <summary>
    /// Validate entity automatically in all mediatr request and response objects
    /// </summary>
    /// <typeparam name="TRequest">Any IRequest Object</typeparam>
    /// <typeparam name="TResponse">AppResponse Object</typeparam>
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : AppResponse
    {
        private ILogger<ValidationBehaviour<TRequest, TResponse>> logger;
        private readonly IValidator validator;
        public ValidationBehaviour()
        {
            validator = CreateInstance<TRequest>();
            this.logger = logger;
        }

        private IValidator CreateInstance<T>()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string requestName = typeof(T).Name;

            //Get string without Request suffix
            int requestNameIndex = requestName.IndexOf("Request");

            //Get request name without Query or Command Suffix
            string actualRequestName = requestName.Contains("Query")
                ? requestName.Substring(0, requestNameIndex - 5)
                : requestName.Substring(0, requestNameIndex - 7);

            //Add validator suffix to target name
            string targetValidator = string.Concat(actualRequestName, "Validator");

            //Get types where ends with Validator suffix
            var typeList = assembly.GetTypes().Where(x => x.Name.EndsWith("Validator")).ToList();
            var validatorType = typeList.FirstOrDefault(x => x.Name == targetValidator);
            return validatorType == null
                ? null
                : (IValidator)Activator.CreateInstance(validatorType);
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (validator != null)
            {
                //First solution
                //var result = validator.Validate(new ValidationContext<Object>(request));
                //Second solution
                var context = new ValidationContext<Object>(request);
                var result = await validator.ValidateAsync(context, cancellationToken);
                if (result.Errors.Count > 0)
                {
                    logger.LogError($"Validation Error Message : {result.Errors.First().ErrorMessage}");
                    return (TResponse)await Task.FromResult<AppResponse>(new ErrorResponse(result.Errors.First().ErrorMessage));
                }
            }
            return await next();
            //TODO: Doesnt work this behaviour class
        }
    }
}
