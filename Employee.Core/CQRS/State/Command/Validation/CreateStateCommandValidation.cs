using Employee.Core.CQRS.Country.Command;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.CQRS.State.Command.Validation;

public class CreateStateCommandValidation : AbstractValidator<CreateStateCommand>
{
    public CreateStateCommandValidation()
    {
        RuleFor(x => x.MCountries).NotEmpty();
    }
}