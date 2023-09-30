using Employee.Shared;
using Employee.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Employee.Model;

public class States:BaseAuditableEntity,IEntity
{
    public int Id { get; set; }
    public string? StateName { get; set; }
    public int CountryId  { get; set; }
    public Countries? Countries { get; set; }

    [JsonIgnore]
    public ICollection<Employees> Employees { get; set; } = new HashSet<Employees>();
}
