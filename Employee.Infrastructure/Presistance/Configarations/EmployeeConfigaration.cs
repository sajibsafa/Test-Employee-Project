using Employee.Model;
using Employee.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employee.Infrastructure.Presistance.Configarations;

public class EmployeeConfigaration : IEntityTypeConfiguration<Employees>
{
    public void Configure(EntityTypeBuilder<Employees> builder)
    {
        builder.ToTable("Employee",schema: "Emp");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.FirstName);
        builder.HasOne(x=>x.Countries).WithMany(x=>x.Employees).HasForeignKey(x => x.CountryId); //new 16/9/2023
        builder.HasOne(x => x.States).WithMany(x=>x.Employees).HasForeignKey(x => x.StateId); //new 16/9/2023
        builder.HasData(new
        {
            Id = 1,
            FirstName = "M.A. Monaem",
            LastName = "Khan",
            Address = "Dhaka",
            Age = 26,
            PhoneNumber = "01303271849",
            CountryId = 1,
            StateId = 1,
            CreatedBy = "1",
            Created = DateTimeOffset.Now,
            Status = EntityStatus.Created
        }, new {
            Id = 2,
            FirstName = "M.A.",
            LastName = "Khan",
            Address = "Dhaka",
            Age = 26,
            PhoneNumber = "013",
            CountryId = 2,
            StateId = 3,
            CreatedBy = "1",
            Created = DateTimeOffset.Now,
            Status = EntityStatus.Created
        });
    }
}
