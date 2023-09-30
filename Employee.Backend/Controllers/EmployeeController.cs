using Employee.Core.CQRS.Employee.Command;
using Employee.Core.CQRS.Employee.Query;
using Employee.Service.Model;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Backend.Controllers;

[Route("Employee")]
public class EmployeeController : APIController
{
    [HttpGet("Id:int")]
    public async Task<ActionResult<VMEmployee>> GetById(int Id)=>await HandleQueryAsync(new GetAllEmployeeByIdQuery(Id));

    [HttpGet]
    public async Task<ActionResult<VMEmployee>> GetAllEmployee()=>await HandleQueryAsync(new GetAllEmployee());

    [HttpPost]
    public async Task<ActionResult<VMEmployee>> InsertEmployee(VMEmployee data)
    {
        return await HandleCommandAsync(new CreateEmployeeCommand(data));
    }
    [HttpPut]
    public async Task<ActionResult<VMEmployee>> UpdateEmployee(int Id, VMEmployee data)
    {
        return await HandleCommandAsync(new UpdateEmplyeeCommand(Id, data));
    }
    [HttpDelete]
    public async Task<ActionResult<VMEmployee>> DeleteEmployee(int Id)
    {
        return await HandleCommandAsync(new DeleteEmployeeCommand(Id));
    }
}
