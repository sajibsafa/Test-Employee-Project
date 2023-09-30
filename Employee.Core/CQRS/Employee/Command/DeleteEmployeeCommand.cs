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

public record DeleteEmployeeCommand(int Id):IRequest<CommandResult<VMEmployee>>;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, CommandResult<VMEmployee>>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IValidator<DeleteEmployeeCommand> _validator;

    public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository, IValidator<DeleteEmployeeCommand> validator)
    {
        _employeeRepository = employeeRepository;
        _validator = validator;
    }


    public async Task<CommandResult<VMEmployee>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var validator = await _validator.ValidateAsync(request, cancellationToken);
        if (!validator.IsValid)
        {
            throw new ValidationException(validator.Errors);
        }
        var result = await _employeeRepository.DeleteAsync(request.Id);
        return result switch
        {
            null => new CommandResult<VMEmployee>(null, CommandResultTypeEnum.NotFound),
            _ => new CommandResult<VMEmployee>(result, CommandResultTypeEnum.Success)
        };
    }
}
