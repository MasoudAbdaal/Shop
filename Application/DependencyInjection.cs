using System.Reflection;
using MediatR;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;


public static class ApplicationExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        service.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return service;

    }
}