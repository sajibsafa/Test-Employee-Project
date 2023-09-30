using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.CQRS.Country.Query.Validation;

public class GetAllCountryByIdValidatror: AbstractValidator<GetAllCountryByIDQuery>
{
    public GetAllCountryByIdValidatror()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is Requried");
    }
}
