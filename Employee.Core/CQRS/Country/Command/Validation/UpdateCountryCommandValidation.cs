using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.CQRS.Country.Command.Validation;

public class UpdateCountryCommandValidation:AbstractValidator<UpdateContryCommand>
{
    public UpdateCountryCommandValidation()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is Requried");
    }
}
