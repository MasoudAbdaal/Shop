using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Contracts.Constants.Countries;

namespace Infrastructure.Persistence.Configurations;
public class RegionsConfigurations : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.HasKey(x => x.RegionID);


        builder.HasData(USA, California, Jefferson, Hawaii, SubState2, SubState3, Iran, Tehran, Karaj, Mazandaran, RaamSar, Babol);

        builder.Property(r => r.RegionID).IsRequired().HasColumnName("id");
        builder.Property(r => r.Name).HasColumnName("name").HasMaxLength(20);
        builder.Property(r => r.ParentID).HasColumnName("parent_id");

        builder.HasOne(r => r.ParentRegion).WithMany(r => r.SubRegions).HasForeignKey(r => r.ParentID).OnDelete(DeleteBehavior.Restrict);
    }
}