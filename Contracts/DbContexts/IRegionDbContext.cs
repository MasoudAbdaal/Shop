using Domain.Entities.Address;
using Microsoft.EntityFrameworkCore;

namespace Contracts.DbContexts;

public interface IRegionDbContext
{
    DbSet<Region>? Regions { get; set; }
}