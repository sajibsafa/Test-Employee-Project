using AutoMapper;
using Employee.Model;
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

namespace Employee.Core.CQRS.State.Command;

public record CreateStateCommand(VMState MCountries) : IRequest<CommandResult<VMState>>;

public class CreateStateCommandHandler : IRequestHandler<CreateStateCommand, CommandResult<VMState>>
{
    private readonly IStateRepository _countryRepository;
    private readonly IValidator<CreateStateCommand> _validator;
    private readonly IMapper _mapper;

    public CreateStateCommandHandler(IStateRepository countryCommand, IValidator<CreateStateCommand> validator, IMapper mapper)
    {
        _countryRepository = countryCommand;
        _validator = validator;
        _mapper = mapper;
    }
    public async Task<CommandResult<VMState>> Handle(CreateStateCommand request, CancellationToken cancellationToken)
    {
        var validate = await _validator.ValidateAsync(request, cancellationToken);
        if (!validate.IsValid)
        {
            throw new ValidationException(validate.Errors);
        }
        var data = _mapper.Map<States>(request.MCountries);
        var result = await _countryRepository.InsertAsync(data);
        return result switch
        {
            null => new CommandResult<VMState>(null, CommandResultTypeEnum.NotFound),
            _ => new CommandResult<VMState>(result, CommandResultTypeEnum.Success)
        };
    }
}