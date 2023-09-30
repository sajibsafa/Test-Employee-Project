using Employee.Core.CQRS.Country.Query;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.CQRS.State.Query.Validation;

public class GetStateByIdValidation : AbstractValidator<GetStateByIdQuery>
{
    public GetStateByIdValidation()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is Requried");
    }
}