using Microsoft.Extensions.DependencyInjection;

public static class RepositoryExtensions
{
  public static void ConfigureRepositoryManager(this IServiceCollection services) =>
  services.AddScoped<IRepositoryManager, RepositoryManager>();
}