using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.CQRS.Country.Command.Validation;

public class CreateCountryCommandValidation: AbstractValidator<CreateCountryCommand>
{
    public CreateCountryCommandValidation()
    {
        RuleFor(x => x.MCountries).NotEmpty();
    }
}
