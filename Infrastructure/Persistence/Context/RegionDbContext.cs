using Contracts.DbContexts;
using Domain.Entities.Address;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

internal sealed class RegionDbContext : ModuleDbContext, IRegionDbContext

{
    public DbSet<Region>? Regions { get; set; }

    protected override string Schema => "Shop";

    public RegionDbContext(DbContextOptions options) : base(options)
    {
        Regions = Set<Region>();
    }

}