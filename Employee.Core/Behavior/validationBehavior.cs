using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Behavior;

public class validationBehavior<TRequest,TResponce> : IPipelineBehavior<TRequest,TResponce>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    public validationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponce> Handle(TRequest request, RequestHandlerDelegate<TResponce> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            var validationResult = await Task.WhenAll(
                _validators.Select(v=> v.ValidateAsync(context,cancellationToken)));
            var failures = validationResult.Where(r=>r.Errors.Any()).SelectMany(r=>r.Errors).ToList();
            if(failures.Any())
            {
                throw new ValidationException(failures);
            }
        }

        return await next();
    }


}
