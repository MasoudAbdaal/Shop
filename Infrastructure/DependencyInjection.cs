using Contracts.DbContext;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NetTopologySuite.Index.KdTree;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.RegisterDbContext<IUserDbContext, UserDbContext>(config);
        return services;
    }

    private static IServiceCollection RegisterDbContext<U, T>(this IServiceCollection services, IConfiguration config)
     where U : class
     where T : ModuleDbContext, U
    {

        services.AddDbContext<U, T>(options =>
            options.UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); }))
            .UseSqlServer(config.GetValue<string>("Database:ConnectionString"),
             x =>
             {
                 x.UseNetTopologySuite();
                 x.MigrationsAssembly(typeof(T).Assembly.FullName);
             })
             );

        using (var score = services.BuildServiceProvider().CreateScope())
        {
            var context = score.ServiceProvider.GetRequiredService<T>();
            context.Database.Migrate();
        }
        return services;
    }
}