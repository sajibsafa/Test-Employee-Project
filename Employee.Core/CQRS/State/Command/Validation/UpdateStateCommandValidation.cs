using Employee.Core.CQRS.Country.Command;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.CQRS.State.Command.Validation;

public class UpdateStateCommandValidation : AbstractValidator<UpdateStateCommand>
{
    public UpdateStateCommandValidation()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is Requried");
    }
}