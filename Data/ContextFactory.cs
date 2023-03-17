using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Shop.Data;

public class ContextFactory : IDesignTimeDbContextFactory<MainContext>
{
  public MainContext CreateDbContext(string[] args)
  {

    IConfigurationRoot Configuration = new ConfigurationBuilder()
   .SetBasePath(Directory.GetParent("./")!.FullName)
   .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
   .Build();

    DbContextOptionsBuilder Builder = new DbContextOptionsBuilder<MainContext>()
    .UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); }))
    .UseSqlServer(Configuration.GetValue<string>("Database:ConnectionString")
    , x => x.UseNetTopologySuite());

    return new MainContext(Builder.Options);
  }
}