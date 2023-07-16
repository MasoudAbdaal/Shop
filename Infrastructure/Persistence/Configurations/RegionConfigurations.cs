using System.ComponentModel.DataAnnotations.Schema;
using Contracts.Constants;
using Domain.Entities.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;
public class RegionsConfigurations : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.HasKey(x => x.RegionID);

        builder.HasData(Countries.USA, Countries.IRAN);

        builder.Property(r => r.RegionID).IsRequired().HasColumnName("id");
        builder.Property(r => r.Name).HasColumnName("name").HasMaxLength(20);
        builder.Property(r => r.ParentID).HasColumnName("parent_id");
        builder.Property(r => r.Parent).IsRequired(false);


        builder.HasOne(r => r.Parent).WithMany(r => r.SubRegions).HasForeignKey(r => r.ParentID).OnDelete(DeleteBehavior.Restrict);
    }
}