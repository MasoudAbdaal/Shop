using Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

public class ContextFactory : IDesignTimeDbContextFactory<MainContext>
{
    public MainContext CreateDbContext(string[] args)
    {

        IConfigurationRoot Configuration = new ConfigurationBuilder()
       .SetBasePath(Directory.GetParent("./")!.FullName)
       .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
       .Build();

        // var ConnectionString = new SqlConnection(Configuration.GetValue<string>("Database:ConnectionString"));

        DbContextOptionsBuilder Builder = new DbContextOptionsBuilder<MainContext>()
        .UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); }))
        .UseSqlServer(Configuration.GetValue<string>("Database:ConnectionString"),
        // .UseSqlServer(Configuration["Database:ConnectionString"],
        // .UseSqlServer(ConnectionString,
         x => x.UseNetTopologySuite()
        );

        return new MainContext((DbContextOptions<MainContext>)Builder.Options);
    }
}