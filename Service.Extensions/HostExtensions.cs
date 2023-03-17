public static class HostExtensions
{
  public static void ConfigureIISIntegration(this IServiceCollection services) =>
  services.Configure<IISOptions>(options => { });
}