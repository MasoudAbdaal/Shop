using Contracts.DbContexts;
using Domain.Entities.Address;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context;
internal sealed class RegionDbContext : ModuleDbContext, IRegionDbContext
{
    public DbSet<Region>? Regions { get; set; }


    public RegionDbContext(DbContextOptions<RegionDbContext> options) : base(options)
    {
        Regions = Set<Region>();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

}