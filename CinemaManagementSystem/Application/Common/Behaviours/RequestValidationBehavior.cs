namespace CinemaManagementSystem.Application.Common.Behaviours
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Exceptions;
    using FluentValidation;
    using MediatR;
    public class RequestValidationBehavior<TReqeust, TResponse>
        : IPipelineBehavior<TReqeust, TResponse>
        where TReqeust : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TReqeust>> validators;

        public RequestValidationBehavior(IEnumerable<IValidator<TReqeust>> validators)
            => this.validators = validators;

        public Task<TResponse> Handle(
            TReqeust request, 
            CancellationToken cancellationToken, 
            RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext(request);

            var errors = this
                .validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (errors.Count() != 0)
            {
                throw new ModelValidationException(errors);
            }

            return next();
        }
    }
}
