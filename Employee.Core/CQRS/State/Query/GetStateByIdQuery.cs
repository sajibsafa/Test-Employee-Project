using Employee.Repository.Interface;
using Employee.Service.Model;
using Employee.Shared.Models;
using FluentValidation;
using MediatR;


namespace Employee.Core.CQRS.State.Query;

public record GetStateByIdQuery(int Id) : IRequest<QueryResult<VMState>>;

public class GetStateByIdQueryHandler : IRequestHandler<GetStateByIdQuery, QueryResult<VMState>>
{
    private readonly IStateRepository _countryRepository;
    private readonly IValidator<GetStateByIdQuery> _validator;

    public GetStateByIdQueryHandler(IStateRepository countryRepository, IValidator<GetStateByIdQuery> validator)
    {
        _countryRepository = countryRepository;
        _validator = validator;
    }

    public async Task<QueryResult<VMState>> Handle(GetStateByIdQuery request, CancellationToken cancellationToken)
    {
        var validate = await _validator.ValidateAsync(request, cancellationToken);
        if (!validate.IsValid)
        {
            throw new ValidationException(validate.Errors);
        }
        var country = await _countryRepository.GetByIdAsync(request.Id);
        return country switch
        {
            null => new QueryResult<VMState>(null, QueryResultTypeEnum.NotFound),
            _ => new QueryResult<VMState>(country, QueryResultTypeEnum.Success)
        };
    }
}