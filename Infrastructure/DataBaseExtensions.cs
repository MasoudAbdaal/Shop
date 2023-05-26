using System.Reflection.Metadata.Ecma335;
using Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

public static class DataBaseExtensions
{
    public static IServiceCollection ConfigureContextFactory(this IServiceCollection services)
    {
        services.AddSingleton(new ContextFactory().CreateDbContext(null!));
        // services.AddDbContext<MainContext>();
        // services.AddDbContext<MainContext>(options =>
        // {
        //     //             IConfigurationRoot Configuration = new ConfigurationBuilder()
        //     // .SetBasePath(Directory.GetParent("./")!.FullName)
        //     // .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
        //     // .Build();

        //     // var ConnectionString = new SqlConnection(Configuration.GetValue<string>("Database:ConnectionString"));

        //     // DbContextOptionsBuilder Builder = new DbContextOptionsBuilder<MainContext>()
        //     options.UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); }))
        //     .UseSqlServer(configuration.GetValue<string>("Database:ConnectionString"),

        //      x => x.UseNetTopologySuite()
        //     );

        // });

        return services;
    }
}