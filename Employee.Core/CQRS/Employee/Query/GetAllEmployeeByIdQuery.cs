using Employee.Repository.Interface;
using Employee.Service.Model;
using Employee.Shared.Contracts;
using Employee.Shared.Models;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace Employee.Core.CQRS.Employee.Query;

public record GetAllEmployeeByIdQuery : IRequest<QueryResult<VMEmployee>>
{
    [JsonConstructor]
    public GetAllEmployeeByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }

    public class GetEmployeeByIdQueryHander : IRequestHandler<GetAllEmployeeByIdQuery, QueryResult<VMEmployee>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IValidator<GetAllEmployeeByIdQuery> _validator;

        public GetEmployeeByIdQueryHander(IEmployeeRepository employeeRerpository, IValidator<GetAllEmployeeByIdQuery> validator)
        {
            _employeeRepository = employeeRerpository;
            _validator = validator;
        }

        public async Task<QueryResult<VMEmployee>> Handle(GetAllEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var validate = await _validator.ValidateAsync(request, cancellationToken);
            if (!validate.IsValid)
            {
                throw new ValidationException(validate.Errors);
            }
            var employee = await _employeeRepository.GetByIdAsync(request.Id);
            return employee switch
            {
                null => new QueryResult<VMEmployee>(null, QueryResultTypeEnum.NotFound),
                _ => new QueryResult<VMEmployee>(employee, QueryResultTypeEnum.Success)
            };
        }
    } 
}
