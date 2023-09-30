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

public record UpdateStateCommand(int Id, VMState contry) : IRequest<CommandResult<VMState>>;

public class UpdateStateCommandHandler : IRequestHandler<UpdateStateCommand, CommandResult<VMState>>
{
    private readonly IStateRepository _countryRepository;
    private readonly IValidator<UpdateStateCommand> _validator;
    private readonly IMapper _mapper;

    public UpdateStateCommandHandler(IStateRepository countryRepository, IValidator<UpdateStateCommand> validator, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _validator = validator;
        _mapper = mapper;
    }
    public async Task<CommandResult<VMState>> Handle(UpdateStateCommand request, CancellationToken cancellationToken)
    {
        var validate = await _validator.ValidateAsync(request, cancellationToken);
        if (!validate.IsValid)
        {
            throw new ValidationException(validate.Errors);
        }
        var data = _mapper.Map<States>(request.contry);
        var result = await _countryRepository.UpdateAsync(request.Id, data);
        return result switch
        {
            null => new CommandResult<VMState>(null, CommandResultTypeEnum.UnprocessableEntity),
            _ => new CommandResult<VMState>(result, CommandResultTypeEnum.Success)
        };
    }
}