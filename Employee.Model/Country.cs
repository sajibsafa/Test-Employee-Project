using Employee.Shared.Common;
using Employee.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Employee.Model;

public class Countries : BaseAuditableEntity, IEntity
{
    public int Id { get; set; }
    public string? CountryName { get; set; }
    public string? Courencies {  get; set; }

    [JsonIgnore]
    public ICollection<Employees> Employees { get; set; } = new HashSet<Employees>();

    [JsonIgnore]
    public ICollection<States> States { get; set; } = new HashSet<States>();
}
