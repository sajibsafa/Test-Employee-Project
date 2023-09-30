using Employee.Repository.Interface;
using Employee.Service.Model;
using Employee.Shared.Models;
using MediatR;


namespace Employee.Core.CQRS.Employee.Query;

public record GetAllEmployee: IRequest<QueryResult<IEnumerable<VMEmployee>>>;

    public class GetEmployeeHander : IRequestHandler<GetAllEmployee, QueryResult<IEnumerable<VMEmployee>>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeHander(IEmployeeRepository employeeRerpository)
        {
            _employeeRepository = employeeRerpository;
        }

        public async Task<QueryResult<IEnumerable<VMEmployee>>> Handle(GetAllEmployee request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetAllAsync();
            return employee switch
            {
                null => new QueryResult<IEnumerable<VMEmployee>>(null, QueryResultTypeEnum.NotFound),
                _ => new QueryResult<IEnumerable<VMEmployee>>( employee, QueryResultTypeEnum.Success)
            };
        }
    }
