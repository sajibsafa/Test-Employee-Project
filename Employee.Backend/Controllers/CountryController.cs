using Employee.Core.CQRS.Country.Command;
using Employee.Core.CQRS.Country.Query;
using Employee.Core.CQRS.Employee.Command;
using Employee.Service.Model;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Backend.Controllers;

[Route("Country")]
public class CountryController : APIController
{
    [HttpGet]
    public async Task<ActionResult<VMCountries>> GetAllCountry()
    {
        return await HandleQueryAsync(new GetAllCountryQuery());
    }

    [HttpGet("Id:int")]
    public async Task<ActionResult<VMCountries>> GetCountry(int Id)
    {
        return await HandleQueryAsync(new GetAllCountryByIDQuery(Id));
    }
    [HttpPost]
    public async Task<ActionResult<VMCountries>> InsertCountry(VMCountries data)
    {
        return await HandleCommandAsync(new CreateCountryCommand(data));
    }
    [HttpPut("{Id:int}")]
    public async Task<ActionResult<VMCountries>> UpdateCountry(int Id, VMCountries data)
    {
        return await HandleCommandAsync(new UpdateContryCommand(Id, data));
    }
    [HttpDelete("{Id:int}")]
    public async Task<ActionResult<VMCountries>> DeleteCountry(int Id)
    {
        return await HandleCommandAsync(new DeleteCountryCommand(Id));
    }
}
