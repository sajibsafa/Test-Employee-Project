using Employee.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Service.Model;

public class VMCountries : IVM
{
    public int Id { get; set; }
    public string? CountryName { get; set; }
    public string? Courencies { get; set; }
}
