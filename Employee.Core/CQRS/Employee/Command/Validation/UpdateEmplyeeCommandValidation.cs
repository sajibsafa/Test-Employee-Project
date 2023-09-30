using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.CQRS.Employee.Command.Validation;

public class UpdateEmplyeeCommandValidation:AbstractValidator<UpdateEmplyeeCommand>
{
    public UpdateEmplyeeCommandValidation()
    {
        RuleFor(x=>x.Id).NotEmpty().WithMessage("Id is Requried");
    }
}
