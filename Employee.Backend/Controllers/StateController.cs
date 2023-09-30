using Employee.Core.CQRS.Country.Command;
using Employee.Core.CQRS.Country.Query;
using Employee.Core.CQRS.State.Command;
using Employee.Core.CQRS.State.Query;
using Employee.Service.Model;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Backend.Controllers;

[Route("State")]
public class StateController : APIController
{
    [HttpGet]
    public async Task<ActionResult<VMState>> GetAllState()
    {
        return await HandleQueryAsync(new GetAllStateQuery());
    }
    [HttpGet("Id:int")]
    public async Task<ActionResult<VMState>> GetState(int Id)
    {
        return await HandleQueryAsync(new GetStateByIdQuery(Id));
    }
    [HttpPost]
    public async Task<ActionResult<VMState>> InsertState(VMState data)
    {
        return await HandleCommandAsync(new CreateStateCommand(data));
    }
    [HttpPut]
    public async Task<ActionResult<VMState>> UpdateState(int Id, VMState data)
    {
        return await HandleCommandAsync(new UpdateStateCommand(Id, data));
    }
}
