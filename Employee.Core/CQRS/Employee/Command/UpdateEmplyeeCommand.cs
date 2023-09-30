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

namespace Employee.Core.CQRS.Employee.Command;

public record UpdateEmplyeeCommand(int Id,VMEmployee employee) : IRequest<CommandResult<VMEmployee>>;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmplyeeCommand, CommandResult<VMEmployee>>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IValidator<UpdateEmplyeeCommand> _validator;
    private readonly IMapper _mapper;

    public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository,IValidator<UpdateEmplyeeCommand> validator,IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _validator = validator;
        _mapper = mapper;
    }


    public async Task<CommandResult<VMEmployee>> Handle(UpdateEmplyeeCommand request, CancellationToken cancellationToken)
    {
        var validator = await _validator.ValidateAsync(request, cancellationToken);
        if (!validator.IsValid)
        {
            throw new ValidationException(validator.Errors);
        }
        var data = _mapper.Map<Employees>(request.employee);
        var result = await _employeeRepository.UpdateAsync(request.Id, data);
        return result switch
        {
            null => new CommandResult<VMEmployee>(null, CommandResultTypeEnum.UnprocessableEntity),
            _ => new CommandResult<VMEmployee>(result, CommandResultTypeEnum.Success)
        };
    }
}
