using Employee.Model;
using Employee.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Presistance.Configarations;

public class StateConfiguration : IEntityTypeConfiguration<States>
{
    public void Configure(EntityTypeBuilder<States> builder)
    {
        builder.HasKey(x=> x.Id);
        builder.HasIndex(x => x.StateName);
        builder.HasOne(x=>x.Countries).WithMany(x=>x.States).HasForeignKey(x=>x.CountryId);
        builder.HasData(new
        {
            Id = 1,
            StateName = "Dhaka",
            CountryId = 1,
            CreatedBy = "1",
            Created = DateTimeOffset.Now,
            Status = EntityStatus.Created
        }, new
        {
            Id = 2,
            StateName = "Rajshahi",
            CountryId = 1,
            CreatedBy = "1",
            Created = DateTimeOffset.Now,
            Status = EntityStatus.Created
        }, new
        {
            Id = 3,
            StateName = "Mumbai",
            CountryId = 2,
            CreatedBy = "1",
            Created = DateTimeOffset.Now,
            Status = EntityStatus.Created
        });
    }
}
