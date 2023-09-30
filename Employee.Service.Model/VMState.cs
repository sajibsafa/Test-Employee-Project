using Employee.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Service.Model;

public class VMState:IVM
{
    public int Id { get; set; }
    public string? StateName { get; set; }
    public int CountryId { get; set; }
}
