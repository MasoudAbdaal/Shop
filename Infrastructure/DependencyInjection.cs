using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Contracts.DbContexts;
using Infrastructure.Common;
using Infrastructure.Persistence.Context;
public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.RegisterDbContext<IUserDbContext, UserDbContext>(config);
        services.RegisterDbContext<IAddressDbContext, AddressDbContext>(config);
        services.RegisterDbContext<IRegionDbContext, RegionDbContext>(config);
        services.RegisterDbContext<IUserInfoDbContext, UserInfoDbContext>(config);
        services.RegisterDbContext<IUserAddressDbContext, UserAddressDbContext>(config);

        services.ConfigureAuthentications(config);
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
         ).AddScoped<U, T>();

        using (var scope = services.BuildServiceProvider().CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<T>();
            context.Database.Migrate();
        }
        return services;
    }
}