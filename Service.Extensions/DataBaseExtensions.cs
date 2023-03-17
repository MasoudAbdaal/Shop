using Shop.Data;

public static class DataBaseExtensions
{
  public static void ConfigureContextFactory(this IServiceCollection services) =>
  services.AddSingleton(new ContextFactory().CreateDbContext(null!));
}