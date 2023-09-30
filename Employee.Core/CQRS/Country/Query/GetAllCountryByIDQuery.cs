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
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Employee.Core.CQRS.Country.Query;

public record GetAllCountryByIDQuery(int Id) : IRequest<QueryResult<VMCountries>>;

    public class GetAllCountryByIDQueryHandler : IRequestHandler<GetAllCountryByIDQuery, QueryResult<VMCountries>>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IValidator<GetAllCountryByIDQuery> _validator;

        public GetAllCountryByIDQueryHandler(ICountryRepository countryRepository, IValidator<GetAllCountryByIDQuery> validator)
        {
            _countryRepository = countryRepository;
            _validator = validator;
        }

        public async Task<QueryResult<VMCountries>> Handle(GetAllCountryByIDQuery request, CancellationToken cancellationToken)
        {
            var validate = await _validator.ValidateAsync(request, cancellationToken);
            if (!validate.IsValid)
            {
                throw new ValidationException(validate.Errors);
            }
            var country = await _countryRepository.GetByIdAsync(request.Id);
            return country switch
            {
                null => new QueryResult<VMCountries>(null, QueryResultTypeEnum.NotFound),
                _ => new QueryResult<VMCountries>(country, QueryResultTypeEnum.Success)
            };
        }
    }
