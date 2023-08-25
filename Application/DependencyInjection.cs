using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

public static class ApplicationExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        return service;

    }
}