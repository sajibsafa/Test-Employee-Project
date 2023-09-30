using Employee.Repository.Concrete;
using Employee.Repository.Interface;
using Employee.Service.Model;
using Employee.Shared.Models;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.CQRS.Country.Command;

public record DeleteCountryCommand(int Id) : IRequest<CommandResult<VMCountries>>;

public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, CommandResult<VMCountries>>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IValidator<DeleteCountryCommand> _validator;

    public DeleteCountryCommandHandler(ICountryRepository countryRepository, IValidator<DeleteCountryCommand> validator)
    {
        _countryRepository = countryRepository;
        _validator = validator;
    }
    public async Task<CommandResult<VMCountries>> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        var validate = await _validator.ValidateAsync(request, cancellationToken);
        if (!validate.IsValid)
        {
            throw new ValidationException(validate.Errors);
        }
        var result = await _countryRepository.DeleteAsync(request.Id);
        return result switch
        {
            null => new CommandResult<VMCountries>(null, CommandResultTypeEnum.NotFound),
            _ => new CommandResult<VMCountries>(result, CommandResultTypeEnum.Success)
        };
    }
}
