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

public class CountryConfiguration : IEntityTypeConfiguration<Countries>
{
    public void Configure(EntityTypeBuilder<Countries> builder)
    {
        builder.ToTable("Country", schema: "Emp");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.CountryName);
        builder.HasData(new
        {
            Id = 1,
            CountryName = "BanglaDesh",
            Courencies = "Taka",
            CreatedBy = "1",
            Created = DateTimeOffset.Now,
            Status = EntityStatus.Created
        }, new
        {
            Id = 2,
            CountryName = "India",
            Courencies = "Rupi",
            CreatedBy = "1",
            Created = DateTimeOffset.Now,
            Status = EntityStatus.Created
        });
    }
}
