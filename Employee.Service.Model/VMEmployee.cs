using Employee.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Service.Model;

public class VMEmployee : IVM
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }
    ///// <summary>
    ///// Name
    ///// </summary>
    //public string? Name { get; set; }
    /// <summary>
    /// First Name
    /// </summary>
    public string? FirstName { get; set; }
    /// <summary>
    /// Last Name
    /// </summary>
    public string? LastName { get; set; }
    /// <summary>
    /// Address
    /// </summary>
    public string? Address { get; set; }
    /// <summary>
    /// Age
    /// </summary>
    public int Age { get; set; }
    /// <summary>
    /// Phone Number
    /// </summary>
    public string? PhoneNumber { get; set; }

    //new
    public int CountryId { get; set; }
    public int StateId { get; set; }
}
