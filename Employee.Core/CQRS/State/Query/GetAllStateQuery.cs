using Employee.Repository.Interface;
using Employee.Service.Model;
using Employee.Shared.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.CQRS.State.Query;

public record GetAllStateQuery : IRequest<QueryResult<IEnumerable<VMState>>>;

public class GetAllStateQueryHander : IRequestHandler<GetAllStateQuery, QueryResult<IEnumerable<VMState>>>
{
    private readonly IStateRepository _countryRepository;

    public GetAllStateQueryHander(IStateRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<QueryResult<IEnumerable<VMState>>> Handle(GetAllStateQuery request, CancellationToken cancellationToken)
    {
        var country = await _countryRepository.GetAllAsync(x=>x.Countries);
        return country switch
        {
            null => new QueryResult<IEnumerable<VMState>>(null, QueryResultTypeEnum.NotFound),
            _ => new QueryResult<IEnumerable<VMState>>(country, QueryResultTypeEnum.Success)
        };
    }
}