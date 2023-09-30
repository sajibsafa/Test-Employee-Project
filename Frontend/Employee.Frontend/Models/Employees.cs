namespace Employee.Frontend.Models;

public class Employees
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Address { get; set; }

    public int Age { get; set; }

    public string? PhoneNumber { get; set; }

    public int CountryId { get; set; }

    public int StateId { get; set; }
}
