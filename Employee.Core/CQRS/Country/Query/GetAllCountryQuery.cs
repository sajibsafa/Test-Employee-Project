using Employee.Repository.Interface;
using Employee.Service.Model;
using Employee.Shared.Models;
using MediatR;

namespace Employee.Core.CQRS.Country.Query;

public record GetAllCountryQuery:IRequest<QueryResult<IEnumerable<VMCountries>>>;

public class GetAllCountryQueryHander : IRequestHandler<GetAllCountryQuery, QueryResult<IEnumerable<VMCountries>>>
{
    private readonly ICountryRepository _countryRepository;

    public GetAllCountryQueryHander(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<QueryResult<IEnumerable<VMCountries>>> Handle(GetAllCountryQuery request, CancellationToken cancellationToken)
    {
        var country = await _countryRepository.GetAllAsync();
        return country switch
        {
            null => new QueryResult<IEnumerable<VMCountries>>(null, QueryResultTypeEnum.NotFound),
            _ => new QueryResult<IEnumerable<VMCountries>>(country, QueryResultTypeEnum.Success)
        };
    }
}