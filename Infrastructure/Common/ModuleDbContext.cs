using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Common;

public abstract class ModuleDbContext : DbContext
{
    protected abstract string Schema { get; }

    protected ModuleDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        IConfigurationRoot Configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetParent("./")!.FullName)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
    .Build();


        optionsBuilder
        .UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); }))
        .UseSqlServer(Configuration.GetValue<string>("Database:ConnectionString"),
         x => x.UseNetTopologySuite()
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (!string.IsNullOrWhiteSpace(Schema))
            modelBuilder.HasDefaultSchema(Schema);

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => await base.SaveChangesAsync(true, cancellationToken);
}